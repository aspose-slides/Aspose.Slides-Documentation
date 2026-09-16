---
title: .NET에서 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/net/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 온전하게 유지합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법을 시연합니다(숨겨진 슬라이드 내보내기 포함). 또한 대체 폰트, XAML 스택 호환성 및 숨긴 슬라이드 내보내기 동작과 관련된 일반적인 질문 몇 가지에 대한 답변도 제공합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin.Forms와 같은 프레임워크에서 사용자 인터페이스를 설명하기 위해 사용되는 XML 기반 마크업 언어입니다.

시각 디자이너에서 XAML 파일을 작업하거나 마크업을 직접 작성·편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 C# 예제는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

기본적으로 내보낸 슬라이드는 프로세스의 현재 작업 디렉터리(`Directory.GetCurrentDirectory`가 반환) 하위 폴더 `pres`에 저장됩니다. 폴더는 자동으로 생성되며 필요한 이미지도 동일한 위치에 저장됩니다.

출력 폴더 이름은 원본 파일 이름에서 확장자를 제외한 값에서 가져옵니다. `pres.pptx`의 경우 출력 파일은 `pres/Slide_1.xaml`, `pres/Slide_2.xaml` 등으로 이름이 지정됩니다. 입력 프레젠테이션에 절대 경로를 전달하더라도 출력 폴더는 현재 작업 디렉터리를 기준으로 생성되며 입력 파일 옆에 생성되지 않습니다.

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

`[IXamlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/ixamloptions/)` 인터페이스를 사용하여 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 제어할 수 있습니다.

출력을 사용자 지정 위치에 저장하려면 `[IXamlOutputSaver](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/ixamloutputsaver/)`를 구현하고 해당 구현 인스턴스를 `[XamlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/xamloptions/)`의 `OutputSaver` 속성에 할당하십시오.

숨겨진 슬라이드를 XAML 출력에 포함하려면 `ExportHiddenSlides` 속성을 `true` 로 설정하면 됩니다. 아래 C# 예제를 참고하십시오:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **생성된 모든 XAML 아티팩트 캡처하기**

XAML 내보내기는 내보낸 각 슬라이드에 대한 XAML 문서와 별도의 이미지 및 지원 리소스를 생성할 수 있습니다. 기본 파일 시스템 저장소 대신 사용자 지정 `[IXamlOutputSaver](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/ixamloutputsaver/)`를 `XamlOptions.OutputSaver`에 지정하여 이러한 아티팩트를 받아 처리하십시오. XAML 옵션을 받아들이는 `[Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)` 오버로드를 사용해 내보내기를 시작합니다.

### **콜백 수명 주기 이해하기**

내보내기 도구는 생성된 각 아티팩트에 대해 `[IXamlOutputSaver.Save](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/ixamloutputsaver/save/)`를 별도로 호출합니다:

- `path`는 아티팩트를 식별하고 상대 디렉터리를 포함할 수 있습니다. XAML이 상대 경로를 사용해 리소스를 참조할 수 있으므로 이 정보를 보존하십시오.
- `data`는 아티팩트의 바이트 배열을 포함합니다. 이미지 및 기타 바이너리 리소스는 텍스트로 디코딩해서는 안 됩니다.
- 저장소는 반환하기 전에 데이터를 보존하거나 영구 저장할 책임이 있습니다. 예제에서는 각 바이트 배열을 애플리케이션이 소유한 메모리로 복사합니다.
- 프레젠테이션 저장 작업이 반환되고 모든 콜백이 성공적으로 완료될 때만 내보내기가 성공한 것으로 간주하십시오. 저장 오류를 무시하거나 관찰되지 않은 백그라운드 쓰기를 시작하지 마십시오. 영구 저장이 이후에 이루어지는 경우 전체 성공을 해당 단계가 성공한 후에만 보고하십시오.

`[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/)`는 사용자 지정 저장소에도 적용됩니다. 기본값 `false`는 숨겨진 슬라이드의 XAML 문서를 제외합니다. `true` 로 설정하면 숨겨진 슬라이드와 해당 내보내기에 필요한 모든 리소스가 포함됩니다. 리소스 수는 프레젠테이션에 따라 다르며 슬라이드당 하나의 콜백이나 고정된 콜백 순서를 가정하지 마십시오.

### **메모리로 내보내고 아티팩트 검사하기**

다음 완전한 예제는 `pres.pptx`를 로드하고 모든 아티팩트를 `[Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)`에 수집한 뒤 이름, 유형 및 바이트 수를 출력합니다. 제공된 이름은 그대로 보존됩니다. 중복 이름이 있으면 아티팩트가 조용히 덮어쓰기 되지 않고 수집이 실패합니다.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // XAML만 디코드하고, 텍스트 검사가 필요할 때만 수행합니다.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

애플리케이션에서 `InMemoryXamlExample.Run`을 호출하십시오. 확장자 검사는 검증에 유용합니다; 모든 아티팩트(익숙하지 않은 리소스 유형 포함)를 보존하십시오. 저장하거나 전송할 때 바이트를 변경하지 마십시오. 텍스트 처리가 필요한 XAML에만 `[Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring)`을 사용하십시오.

### **수집된 아티팩트를 ZIP 아카이브에 패키징하기**

이 독립 예제는 내보내기를 수집하고 이름을 검증한 뒤 원본 바이트를 ZIP 아카이브에 기록합니다. 고유한 아카이브 이름은 동시 내보내기 작업을 구분합니다. ZIP 항목은 슬래시(`/`)를 사용하고 상대 디렉터리를 유지합니다. 비정상적인 이름이나 정규화 후 충돌하는 이름은 아카이브가 쓰여지기 전에 전체 패키지를 거부합니다.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // 성공을 보고하기 전에 폐기에 의해 ZIP 디렉터리가 최종화되었습니다.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

애플리케이션에서 `ZipXamlExample.Run`을 호출하십시오. 예제는 `[ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive)`을 사용해 로컬 아카이브 하나를 기록합니다; 내보내기 도구 자체는 느슨한 XAML이나 이미지 파일을 쓰지 않습니다. 원격 저장소의 경우, 수집된 바이트 배열을 업로드하는 단계로 아카이브 쓰기 단계를 교체하십시오. 내보내기 작업 식별자와 전체 상대 아티팩트 이름을 블롭 키로 사용하거나 작업 식별자, 상대 이름 및 바이너리 데이터를 데이터베이스 행에 저장하십시오. 모든 업로드가 완료되거나 데이터베이스 트랜잭션이 커밋된 후에만 작업을 공개하십시오. 영구 저장에 실패하면 부분 출력물을 정리하십시오.

큰 프레젠테이션의 경우, 사용자 지정 저장소가 각 아티팩트를 직접 애플리케이션 스토리지에 영구 저장하도록 하면 전체 내보내기를 애플리케이션 메모리에 추가로 보관할 필요가 없습니다. 내보내기 도구는 저장소를 호출하기 전에 여전히 모든 생성된 아티팩트를 메모리에 수집합니다. 내보내기 도구 관점에서 각 콜백을 동기식으로 유지하십시오: 대상이 바이트를 받아들인 후에만 반환하고, 실패가 호출자에게 전달되도록 하십시오.

### **리소스 이름 보존 및 참조 검증하기**

- 대상이 경로 구분자를 요구하는 경우 정규화하되, 상대 디렉터리는 보존하십시오. 모든 생성된 이름이 고유하고 리소스 참조가 유효함이 보장되는 경우가 아니라면 `[Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)`만 사용하지 마십시오.
- 대상 전용 이름 검증을 적용하십시오. 느슨한 파일을 기록할 때 루트 경로나 경로 탐색 세그먼트를 거부하고, `[Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath)`으로 대상 경로를 확인한 뒤 의도된 내보내기 디렉터리 아래에 머무는지(디렉터리 구분자를 포함해) 확인하십시오. 심볼릭 링크가 없는 애플리케이션 제어 디렉터리를 사용하여 리다이렉트를 방지하십시오.
- 각 내보내기 작업마다 별도 저장소와 네임스페이스를 사용하십시오. 구분자 정규화 후 충돌을 감지하고 대상의 대소문자 구분 규칙에 따라 처리하십시오.
- 공개 전에 각 XAML 문서를 XML로 파싱하고 `Source` 또는 `ImageSource`와 같은 파일 기반 리소스 참조를 검사하십시오. 각 상대 URI를 해당 XAML 아티팩트의 디렉터리를 기준으로 해결하고, 결과 저장 이름을 정규화한 뒤 사전 키, ZIP 항목 또는 저장된 객체가 존재하는지 확인하십시오. 외부 URI와 XAML 마크업 표현식은 파일 이름과 별도로 처리하십시오.

예를 들어 `pres/Slide_1.xaml`이 `images/image1.png`를 참조한다면, 저장된 리소스는 `pres/images/image1.png`에 존재해야 합니다. 단순히 `image1.png`만 보관하면 관계가 깨집니다. 객체 스토리지의 경우 작업 접두사 아래에 동일한 레이아웃을 유지하고 해당 리소스 URL을 XAML 소비자가 접근할 수 있도록 하십시오. 완성된 ZIP을 다시 열어 항목 이름과 리소스 바이트를 검증하고, 대상 XAML 환경에서 대표 슬라이드를 로드해 이미지가 올바르게 해석되는지 확인하십시오.

## **FAQ**

**원본 폰트가 머신에 없을 때 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

`[XamlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/xamloptions/)`의 `DefaultRegularFont`를 설정하십시오 — 내보내기 중 원본 폰트가 없을 경우 대체 폰트로 사용됩니다. 이는 생성된 XAML이 대체 폰트를 참조한다거나 대상 머신에 해당 폰트가 존재한다는 것을 보장하지 않습니다. XAML이 참조하는 폰트가 표시 환경에 존재하도록 하십시오.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

Aspose.Slides는 공개 API를 통해 WPF XAML을 내보냅니다. UWP, Xamarin.Forms 등 다른 XAML 스택과의 호환성은 보장되지 않습니다. 대상 환경에서 생성된 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요, 기본적으로 내보내지 않으려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. `[XamlOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export.xaml/xamloptions/)`의 `ExportHiddenSlides` 속성을 사용해 동작을 제어할 수 있습니다—숨겨진 슬라이드를 내보낼 필요가 없으면 해당 옵션을 비활성화하십시오.