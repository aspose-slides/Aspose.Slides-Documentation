---
title: バージョン 26.8 の新しい Python-to-.NET エンジンへの移行
linktitle: 新しいエンジンへの移行
type: docs
weight: 290
url: /ja/python-net/migrate-to-new-engine/
keywords:
- 新エンジン
- 移行
- aspose.pydrawing
- 描画プリミティブ
- Point
- Color
- Rectangle
- ImportError
- AttributeError
- Python
- Aspose.Slides
description: "バージョン 26.8 で新しい Aspose.Slides エンジンに Python コードを移行します。描画プリミティブを aspose.slides に移動し、インポートを自動的に修正します。"
---
## **はじめに**

バージョン 26.8 は、Python と .NET を接続するエンジンを置き換えます。描画プリミティブは `aspose.slides` モジュールに移動しました。

アップグレード後に問題がある場合は、直接[エラーが発生した場合](#i-have-an-error)へジャンプしてください。

### **aspose.slides へ移動した描画プリミティブ**

7 つの型が移動しました。名前、引数、動作はそのままです。

|型|26.8以前|26.8以降|
| :- | :- | :- |
|Point|`aspose.pydrawing.Point`|[aspose.slides.Point](https://reference.aspose.com/slides/ja/python-net/aspose.slides/point/)|
|PointF|`aspose.pydrawing.PointF`|[aspose.slides.PointF](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pointf/)|
|Size|`aspose.pydrawing.Size`|[aspose.slides.Size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/size/)|
|SizeF|`aspose.pydrawing.SizeF`|[aspose.slides.SizeF](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sizef/)|
|Rectangle|`aspose.pydrawing.Rectangle`|[aspose.slides.Rectangle](https://reference.aspose.com/slides/ja/python-net/aspose.slides/rectangle/)|
|RectangleF|`aspose.pydrawing.RectangleF`|[aspose.slides.RectangleF](https://reference.aspose.com/slides/ja/python-net/aspose.slides/rectanglef/)|
|Color|`aspose.pydrawing.Color`|[aspose.slides.Color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/color/)|

これら 7 つの型は `aspose.pydrawing` の残りのすべての内容でした。これらをすべて再指向すると、コード内で `aspose.pydrawing` を参照する必要はなくなり、すべてのインポートを削除できます。これにより結果の確認も容易になります - [移行の検証](#verify-the-migration) を参照してください。

**レガシーコード:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.red

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

**バージョン 26.8:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    with slide.get_image(slides.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

`from` インポート形式も同様に変わります:

```python
# レガシーコード
from aspose.pydrawing import Color, Point

# バージョン 26.8
from aspose.slides import Color, Point
```

## **インポートエラーの修正**

最初の列にスタックトレースがあります。

|エラー|原因|対策|
| :- | :- | :- |
|`AttributeError: module 'aspose.pydrawing' has no attribute 'Color'` (or `Point`, `Rectangle`, and so on)|パッケージは 26.8 ですが、コードは依然として古いモジュールを指しています|[コードを更新する](#update-your-code)|
|`ImportError: cannot import name 'Color' from 'aspose.pydrawing'`|同様の原因、`from` インポート形式|[コードを更新する](#update-your-code)|
|`ModuleNotFoundError: No module named 'aspose.pydrawing'`|`aspose.pydrawing` モジュールとその 7 つの型はすべて `aspose.slides` に移動しました|[コードを更新する](#update-your-code)、その後 `aspose.pydrawing` のインポートを削除してください|
|`ImportError: cannot import name 'Color' from 'aspose.slides'`|コードは移行済みですが、インストールされているパッケージは 26.7 以前です|`pip install --upgrade aspose.slides`|
|`TypeError` on a color, point, or size argument|`aspose.pydrawing` で作成された値が新しい API に渡されています|`aspose.slides` からも同様に値を作成してください|

## **コードの更新**

`aspose.pydrawing` には移動した 7 つの型以外のコンテンツがないため、移行はモジュール名の変更です。エイリアスを含むすべてのインポート形式はこの単一のリネームで対応できます:

```python
# レガシーコード
import aspose.pydrawing as drawing
color = drawing.Color.red

# バージョン 26.8 - エイリアスは引き続き機能します
import aspose.slides as drawing
color = drawing.Color.red
```

これは関数本体内を含む任意のスコープで有効です。エイリアスは元の位置にそのままバインドされるためです。唯一の欠点は名前が誤解を招くことなので、意図を明示的にすることを検討してください:

```python
import aspose.slides as slides
color = slides.Color.red
```

コードベースの規模に合わせてアプローチを選択してください。

### **手動で置換**

ファイルが少数の場合は、`aspose.pydrawing` を検索して `aspose.slides` に置換し、不要になったインポートを削除してください。

### **シェルコマンドで置換**

これは単純なテキスト置換のため、文字列やコメント内の出現も対象になります。両方のコマンドは変更したすべてのファイルに `.bak` のコピーを書き出します。

**Linux:**

```bash
grep -rlZ --include='*.py' 'aspose\.pydrawing' . \
  | xargs -0 -r sed -i.bak 's/aspose\.pydrawing/aspose.slides/g'
```

macOS では、`sed -i ''` を使用し、`sed -i.bak` の代わりに使用するか、GNU sed を `gsed` としてインストールしてください。

**Windows PowerShell:**

```
Get-ChildItem -Recurse -Filter *.py | ForEach-Object {
  $t = Get-Content $_ -Raw
  $new = $t -replace 'aspose\.pydrawing', 'aspose.slides'
  if ($new -ne $t) {
    Copy-Item $_.FullName "$($_.FullName).bak"
    Set-Content $_.FullName $new -NoNewline
    $_.FullName
  }
}
```

Linux または macOS でロールバックするには:

```bash
find . -name '*.py.bak' -exec sh -c 'mv "$1" "${1%.bak}"' _ {} \;
```

Windows でロールバックするには:

```
Get-ChildItem -Recurse -Filter *.py.bak | ForEach-Object {
  Move-Item $_.FullName ($_.FullName -replace '\.bak$', '') -Force
}
```

### **Python スクリプトで置換**

同じ名前変更を行い、Linux、macOS、Windows でポータブルです。スクリプトはパスを引数として受け取り、`--write` が指定されない限り変更内容をプレビューします。`--backup` を追加すると、変更したすべてのファイルの `.bak` コピーが保存されます。任意の名前で保存できます。実行時に使用例メッセージが名前を取得します。

```python
"""aspose.pydrawing を aspose.slides にリネームします。プレーンテキスト置換。

    python <this script> src/                     # プレビュー
    python <this script> src/ --write             # 適用
    python <this script> src/ --write --backup    # 適用、.bak コピーを保持
"""

import sys
from pathlib import Path

W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0

for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    n = s.replace("aspose.pydrawing", "aspose.slides")
    if n == s:
        continue
    changed += 1
    print(("wrote " if W else "would change ") + str(p))
    if W:
        if B:
            p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
        p.write_text(n, encoding="utf-8")

print(f"{changed} file(s) {'changed' if W else 'to change'}"
      + ("" if W or not changed else "; rerun with --write to apply"))
```

典型的な実行例は以下の通りです:

```console
$ python migrate.py src/
would change src/render.py
would change src/export/slides.py
2 file(s) to change; rerun with --write to apply

$ python migrate.py src/ --write --backup
wrote src/render.py
wrote src/export/slides.py
2 file(s) changed
```

パスはディレクトリ（再帰的に走査）または単一の `.py` ファイルを指定できます。

### **AST ベースのスクリプトで置換**

大規模なコードベースに推奨です。このスクリプトは同じ名前変更を行いますが、各ファイルを先に解析するため、文字列、コメント、ドックストリング内の出現には触れません。

`aspose.pydrawing` をインプレースでリネームし、エイリアスはそのままにするため、すべてのインポート形式が特別な処理なしで対応できます: `import aspose.pydrawing`、`import aspose.pydrawing as X`、`from aspose.pydrawing import Color`、`from aspose.pydrawing import Color as C`、複数行の括弧付きインポート、関数内のインポート、モジュールを値として渡すケースなど。`--write` と `--backup` フラグも同様に使用できます。

```python
"""Rename aspose.pydrawing to aspose.slides, skipping strings and comments.

    python <this script> src/                     # preview
    python <this script> src/ --write             # apply
    python <this script> src/ --write --backup    # apply, keeping .bak copies
"""

import ast, sys
from pathlib import Path

MOD, DST = "aspose.pydrawing", "aspose.slides"
W = "--write" in sys.argv
B = "--backup" in sys.argv
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), None)

if ROOT is None:
    sys.exit(f"usage: python {Path(sys.argv[0]).name} <path> [--write] [--backup]")

root = Path(ROOT)
if not root.exists():
    sys.exit(f"no such path: {root}")

files = [root] if root.is_file() else root.rglob("*.py")
changed = 0


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def fix(src):
    tree = ast.parse(src)
    off, o = [], 0
    for l in src.encode().splitlines(keepends=True):
        off.append(o)
        o += len(l)
    off.append(o)
    edits = []

    for n in ast.walk(tree):
        # import aspose.pydrawing [as X]  /  from aspose.pydrawing import ...
        # モジュール名はその場でリネームされるため、エイリアスは以前と同様にバインドされたままです。
        if (isinstance(n, ast.Import) and any(a.name == MOD for a in n.names)) or \
           (isinstance(n, ast.ImportFrom) and n.module == MOD):
            s, e = off[n.lineno - 1], off[n.end_lineno - 1] + n.end_col_offset
            edits.append((s, e, src.encode()[s:e].decode().replace(MOD, DST)))
        # モジュールを参照するすべての式、例えば裸の `fn(aspose.pydrawing)` も含む。
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            edits.append((off[n.lineno - 1] + n.col_offset,
                          off[n.end_lineno - 1] + n.end_col_offset, DST))

    b = src.encode()
    for s, e, r in sorted(edits, reverse=True):  # 後方から前方へ処理することでオフセットが有効に保たれます
        b = b[:s] + r.encode() + b[e:]
    return b.decode()


for p in files:
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    s = p.read_text(encoding="utf-8")
    try:
        n = fix(s)
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    if n != s:
        print(("wrote " if W else "would change ") + str(p))
        if W:
            if B:
                p.with_suffix(p.suffix + ".bak").write_text(s, encoding="utf-8")
            p.write_text(n, encoding="utf-8")
```

両スクリプトとも冪等です。移行済みコードに再度実行しても変化はありません。

## **移行の検証**

テキスト検索で残っているものがあるか確認できます:

```bash
grep -rn 'aspose\.pydrawing' --include='*.py' --exclude-dir=.venv .
```

これは高速ですが、文字列やコメント内も一致するため、クリーンなコードでもヒットすることがあります。確実な結果を得るには、以下のチェックを使用してください。実際のコード参照のみを報告し、残っている場合は非ゼロステータスで終了するため、ビルドゲートとして利用できます。

```python
import ast, sys
from pathlib import Path

MOD = "aspose.pydrawing"
ROOT = next((a for a in sys.argv[1:] if not a.startswith("-")), ".")


def chain(n):
    p = []
    while isinstance(n, ast.Attribute):
        p.append(n.attr)
        n = n.value
    return ".".join(reversed(p + [n.id])) if isinstance(n, ast.Name) else None


def scan(tree):
    for n in ast.walk(tree):
        if isinstance(n, ast.Import) and any(a.name == MOD for a in n.names):
            yield n.lineno, f"import {MOD}"
        elif isinstance(n, ast.ImportFrom) and n.module == MOD:
            names = ", ".join(a.name for a in n.names)
            yield n.lineno, f"from {MOD} import {names}"
        elif isinstance(n, ast.Attribute) and chain(n) == MOD:
            yield n.lineno, f"reference to {MOD}"


hits = 0
for p in sorted(Path(ROOT).rglob("*.py")):
    if {".venv", "venv", "__pycache__", ".git"} & set(p.parts):
        continue
    try:
        tree = ast.parse(p.read_text(encoding="utf-8"))
    except SyntaxError as e:
        print(f"skipped {p}: {e}")
        continue
    for lineno, what in sorted(scan(tree)):
        print(f"{p}:{lineno}: {what}")
        hits += 1

print("migration complete" if not hits else f"{hits} reference(s) left")
sys.exit(1 if hits else 0)
```

移行前後に実行してください:

```console
$ python verify.py src/
src/render.py:4: from aspose.pydrawing import Color, Point
src/render.py:11: import aspose.pydrawing
src/render.py:12: reference to aspose.pydrawing
3 reference(s) left

$ python migrate.py src/ --write
wrote src/render.py

$ python verify.py src/
migration complete
```

最後に、移動した型を対象としたスモークテストを実行してください:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("smoke.pptx", slides.export.SaveFormat.PPTX)
    print("OK")
```

## **推奨される移行手順**

1. **ベースラインを保存する。** 現在のバージョンでテストを実行し、基準のレンダリングを保存します。これにより、後で移行エラーとレンダリング差異を分離できます。
2. **移行のプレビュー。** `--write` なしでスクリプトのいずれかを実行し、変更対象ファイルのリストを確認してください。
3. **適用と検証。** `--write --backup` で実行し、次に検証スクリプトとスモークテストを行います。
4. **許容範囲でレンダリングを比較。** .NET 6 ビルドへの移行により、テキストやエフェクトに微小な差が生じることがあります。バイト単位の比較ではなく、しきい値ベースの比較を使用してください。
5. **バックアップを削除。** 結果が確認できたら、`.bak` ファイルを削除します: Linux と macOS では `find . -name '*.py.bak' -delete`、Windows では `Get-ChildItem -Recurse -Filter *.py.bak | Remove-Item`。

## **1 つのコードベースで両バージョンをサポート**

同一ソースで 26.7 と 26.8 の両方を実行する必要がある場合:

```python
try:
    from aspose.slides import Color, Point, Rectangle      # 26.8 以降
except ImportError:
    from aspose.pydrawing import Color, Point, Rectangle   # 26.7 以前
```

## **変更なし**

- 移動したプリミティブの名前、引数、動作は変わりません。
- `aspose.slides` API の残りの部分は変わりません。
- ライセンスとライセンスファイルの適用方法は変わりません。
- ファイル形式および保存・読み込みの動作は変わりません。
- Windows と macOS のシステム要件は変わりません。
- 別個の .NET インストールが不要である点は変わりません。ランタイムは依然としてバンドルされています。