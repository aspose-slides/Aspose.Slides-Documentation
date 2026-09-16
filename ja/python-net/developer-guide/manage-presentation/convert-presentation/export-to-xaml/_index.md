---
title: Python で XAML にプレゼンテーションをエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/python-net/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して PowerPoint および OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要を含み、デフォルト設定でプレゼンテーションを XAML に保存する方法を示し、[XamlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/) を使用してエクスポートをカスタマイズする方法（非表示スライドのエクスポートを含む）を実演します。また、フォールバックフォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも答えます。

## **XAML について**

XAML は、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するための XML ベースのマークアップ言語です。

XAML ファイルは、ビジュアルデザイナーで操作することも、マークアップを直接記述・編集することもできます。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポート**

以下の Python の例は、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

デフォルトでは、エクスポートされたスライドはプロセスの現在の作業ディレクトリ（[os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) が返す）内の `pres` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同様に保存されます。

出力フォルダー名は、拡張子を除いたソースファイル名から取得されます。たとえば `pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` のように命名されます。入力プレゼンテーションに絶対パスを指定した場合でも、出力フォルダーは現在の作業ディレクトリを基準に作成され、入力ファイルと同じ場所には作られません。

## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[XamlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/) クラスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御します。

XAML 出力に非表示スライドを含めるには、[export_hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) プロパティを `True` に設定します。以下の Python の例をご参照ください。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **生成されたすべての XAML アーティファクトを取得**

XAML エクスポートは、エクスポートされた各スライドに対して XAML ドキュメントを生成し、個別の画像や補助リソースも出力します。エクスポートを保存または転送する際は、これらすべてのファイルを保持してください。

以下の例では、デフォルトのファイルシステムセーバーを一時ディレクトリで使用し、生成されたファイルを収集します。

### **エクスポートライフサイクルの理解**

- XAML 用のオプションを受け取る [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) オーバーロードでエクスポートを開始します。エクスポートが正常に完了した後でのみ生成されたファイルを読み取ります。
- XAML はリソースを相対パスで参照する可能性があるため、各アーティファクトの相対パスを保持します。
- アーティファクトはバイトとして読み取ります。画像やその他のバイナリリソースはテキストとしてデコードしてはいけません。
- コレクションおよびその後の保存処理が完了した後にのみ全体の成功を報告します。保存エラーは呼び出し元に伝え、永続化が失敗した場合は部分的な出力をクリーンアップします。

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) のデフォルトは `False` で、非表示スライドの XAML ドキュメントは除外されます。`True` に設定すると、これらのスライドとエクスポートに必要なすべてのリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドあたり 1 ファイルと想定しないでください。

{{% alert color="warning" title="Warning" %}}
例では一時的にプロセスの現在の作業ディレクトリを変更します。この操作はすべてのスレッドに影響します。エクスポートは専用のワーカープロセスで実行するか、エクスポート中にプロセスの他の作業が現在のディレクトリに依存しないことを確認してください。ユニークな一時ディレクトリだけでは、同一プロセスでの同時エクスポートを安全にすることはできません。
{{% /alert %}}

### **メモリへエクスポートしアーティファクトを検査**

この完全な例では `pres.pptx` を読み込み、一時ディレクトリへエクスポートし、相対名前とバイトの辞書にすべてのアーティファクトを収集して、名前、タイプ、バイト数を出力します。生成されたディレクトリ構造を保持し、収集後に一時ファイルを削除します。作業ディレクトリを変更する前に入力パスを解決します。

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

        # XAML のみをデコードし、テキスト検査が必要な場合にのみ実行します。
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

拡張子チェックは検査に有用です。未知のリソースタイプを含むすべてのアーティファクトを保持してください。保存や転送時にはバイトを変更せずにそのまま扱います。テキスト処理が必要な XAML のみをデコードしてください。このアプローチは、一時的なディスク領域とメモリの両方を使用してエクスポートを収集します。

### **収集したアーティファクトを ZIP アーカイブにパッケージ**

この独立した例では、エクスポートを収集し、名前を検証して、元のバイトを ZIP アーカイブに書き込みます。ユニークなアーカイブ名でエクスポートジョブを区別します。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリを保持します。正規化後に衝突する危険な名前や不正な名前は、書き込む前にパッケージ全体を拒否します。

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP ディレクトリは成功を報告する前に確定されています。
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

この例では、[ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) を使用して、一時エクスポートを収集した後にローカルアーカイブを1つ書き込みます。リモートストレージの場合は、アーカイブ書き込み段階を収集したバイトのアップロードに置き換えてください。エクスポートジョブの識別子と完全な相対アーティファクト名をオブジェクトキーとして使用するか、ジョブ識別子、相対名、バイナリデータをデータベース行に保存します。すべてのアップロードが完了した後、またはデータベーストランザクションがコミットされた後にジョブを公開します。永続化が失敗した場合は部分的な出力をクリーンアップします。

大規模なプレゼンテーションの場合、エクスポート後に一時ファイルを1つずつ処理し、すべてのバイトを辞書に収集しないでください。これにより、エクスポート全体の追加のメモリコピーを回避できますが、エクスポーター自身のメモリ要件はなくなりません。

### **リソース名を保持し参照を検証**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持します。すべての生成名が一意でリソース参照が有効であると確認できない限り、最終的なファイル名だけを残さないでください。
- 宛先固有の名前検証を適用します。緩やかなファイルを書き込む際は、絶対パスや相対パスの遡りセグメントを拒否し、宛先を解決して意図したエクスポートディレクトリ以下に留まることを確認します。書き込み先を書き換える可能性のあるシンボリックリンクのない、アプリケーション管理のディレクトリを使用してください。
- エクスポートジョブごとに別々のストレージ名前空間を使用します。区切り文字正規化後および宛先の大文字小文字感度規則に従って衝突を検出します。
- 公開前に、各 XAML ドキュメントを XML として解析し、画像の `Source` や `ImageSource` 属性など、ファイルベースのリソース参照を検査します。各相対 URI をそれを含む XAML アーティファクトのディレクトリに対して解決し、結果のストレージ名を正規化し、対応する辞書キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI と XAML マークアップ式は、相対ファイル名とは別に扱います。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。`image1.png` だけを保持すると関係が壊れます。オブジェクトストレージの場合、ジョブプレフィックス以下に同じレイアウトを保持し、これらのリソース URL を XAML の利用者がアクセスできるようにします。完了した ZIP を再度開き、エントリ名とリソースバイトを検証し、対象 XAML 環境で代表的なスライドをロードして画像が正しく解決することを確認します。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/) の [default_regular_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) を設定します。これにより、元のフォントが欠如している場合にエクスポート時のフォールバックフォントとして使用されます。ただし、生成された XAML が必ずフォールバックフォントを参照することや、ターゲットマシンでフォントが利用可能になることは保証されません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms などの他の XAML スタックとの互換性は保証されません。生成されたマークアップは、対象環境でテストしてください。

**非表示スライドはサポートされていますか？また、デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[XamlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/) の [export_hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) を使用して動作を制御できます。エクスポートが不要な場合は無効にしたままにしてください。