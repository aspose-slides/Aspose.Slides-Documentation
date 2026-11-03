"""Compile each C# code fence as the only source in a fresh project."""
import argparse
from concurrent.futures import ThreadPoolExecutor
import hashlib
import json
import os
from pathlib import Path
import subprocess
import tempfile
import xml.etree.ElementTree as ET

from verify import CATALOG, C_SHARP_FENCE as FENCE


def project_references(download_project):
    """Use the documented package/framework references without any ZIP build items."""
    source = ET.parse(download_project).getroot()
    project = ET.Element("Project", {"Sdk": "Microsoft.NET.Sdk"})
    settings = ET.SubElement(project, "PropertyGroup")
    for key, value in {
        "OutputType": "Exe", "TargetFramework": "net8.0", "LangVersion": "12.0",
        "RollForward": "Major", "ImplicitUsings": "disable", "Nullable": "enable",
    }.items():
        ET.SubElement(settings, key).text = value
    references = ET.SubElement(project, "ItemGroup")
    for element in source.findall("./ItemGroup/PackageReference"):
        ET.SubElement(references, "PackageReference", element.attrib)
    frameworks = {item.attrib["Include"] for item in source.findall("./ItemGroup/FrameworkReference")}
    if source.attrib.get("Sdk") == "Microsoft.NET.Sdk.Web":
        frameworks.add("Microsoft.AspNetCore.App")
    for framework in sorted(frameworks):
        ET.SubElement(references, "FrameworkReference", {"Include": framework})
    return ET.tostring(project, encoding="unicode")


def collect(content, selected=None):
    root = content / "en/net/examples"
    result = []
    for article, entry in CATALOG["articles"].items():
        if selected and article not in selected:
            continue
        folder = root / article
        blocks = FENCE.findall((folder / "_index.md").read_text(encoding="utf-8-sig"))
        hashes = [hashlib.sha256(code.encode()).hexdigest() for code in blocks]
        if entry.get("snippet_sha256", hashes) != hashes:
            raise ValueError("Printed C# differs from the standalone recipe mapping for " + article)
        project = project_references(folder / "Example.csproj")
        for action, code in zip(entry["actions"], blocks, strict=True):
            result.append((action, code, project))
    if not result or selected and {action.rsplit("/", 1)[0] for action, _, _ in result} != set(selected):
        raise ValueError("Unknown or empty snippet selection")
    return result


def compile_snippet(item, dotnet, work, env, execute=False):
    action, code, project = item
    with tempfile.TemporaryDirectory(prefix="paste ", dir=work) as temporary:
        folder = Path(temporary)
        (folder / "Program.cs").write_text(code, encoding="utf-8", newline="\n")
        (folder / "Pasted.csproj").write_text(project, encoding="utf-8")
        run = subprocess.run(
            [dotnet, "build", "Pasted.csproj", "-c", "Release", "--nologo"],
            cwd=folder, env=env, capture_output=True, text=True, encoding="utf-8", errors="replace", timeout=420,
        )
        result = {
            "action_id": action, "code_sha256": hashlib.sha256(code.encode()).hexdigest(),
            "exit_code": run.returncode,
            **({"log": (run.stdout + run.stderr)[-5000:]} if run.returncode else {}),
        }
        if execute and not run.returncode:
            execution = subprocess.run(
                [dotnet, "run", "--project", "Pasted.csproj", "-c", "Release", "--no-build"],
                cwd=folder, env=env, capture_output=True, text=True, encoding="utf-8", errors="replace", timeout=420,
            )
            result["run_exit_code"] = execution.returncode
            result["run_output"] = (execution.stdout + execution.stderr)[-5000:]
        return result


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--content-root", type=Path, default=Path("."))
    parser.add_argument("--dotnet", default="dotnet")
    parser.add_argument("--out", type=Path, required=True)
    parser.add_argument("--work-root", type=Path, required=True)
    parser.add_argument("--article", action="append")
    parser.add_argument("--workers", type=int, default=2)
    parser.add_argument("--run", action="store_true", help="Run selected programs that need no arguments or services")
    args = parser.parse_args()
    work = args.work_root.resolve()
    work.mkdir(parents=True, exist_ok=True)
    args.out.parent.mkdir(parents=True, exist_ok=True)
    env = {**os.environ, "DOTNET_GENERATE_ASPNET_CERTIFICATE": "false", "NuGetAudit": "false"}
    rows = collect(args.content_root, args.article)
    with ThreadPoolExecutor(max_workers=args.workers) as pool:
        results = list(pool.map(lambda row: compile_snippet(row, args.dotnet, work, env, args.run), rows))
    failed = [row for row in results if row["exit_code"] or row.get("run_exit_code", 0)]
    report = {"result": "fail" if failed else "pass", "source_commit": os.environ.get("GITHUB_SHA"), "count": len(results), "results": results}
    args.out.write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8", newline="\n")
    for row in failed:
        print(row["action_id"], row.get("log", row.get("run_output", "")))
    operation = "compiled and ran" if args.run else "compiled"
    print(f"{len(results) - len(failed)}/{len(results)} pasted snippets {operation}", flush=True)
    return int(bool(failed))


if __name__ == "__main__":
    raise SystemExit(main())
