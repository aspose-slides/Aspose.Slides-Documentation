---
title: Python で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の Python サンプル、エラーハンドリング、精度に関する注意点を含みます。"
---
## **概要**

PPT は従来のバイナリ PowerPoint 形式であり、PPTX は新しい Open XML 形式です。Aspose.Slides for Python via Java は Microsoft PowerPoint を使用せずに PPT ファイルをロードし、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき点を説明します。

各サンプルは必要に応じて Java 仮想マシンを起動し、使用後にプレゼンテーションを解放します。サンプルのパスはご自身のファイルまたはディレクトリのパスに置き換えてください。

## **PPT ファイルを PPTX に変換**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでソース ファイルを読み込み、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を指定して呼び出します。`finally` ブロックでプレゼンテーションを破棄し、リソースを解放します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 旧式の PPT プレゼンテーションを読み込む。
presentation = Presentation("presentation.ppt")
try:
    # プレゼンテーションを PPTX 形式で保存する。
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

拡張子だけでは出力形式は決まりません。実際の形式は [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) 引数で決定されます。元の PPT ファイルを残したい場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換**

次のサンプルは、ディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体は停止しません。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

本番環境では、例外の詳細をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名をリトライまたはレビュー キューに書き込むことを検討してください。破損したファイル、パスワード保護されたファイル（正しいパスワードがない場合）、アクセスできないパス、サポートされていないコンテンツが原因で変換が失敗することがあります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/slides/ja/python-java/password-protected-presentation/) を参照してください。

## **精度とレガシー機能**

変換では通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、テーブル、チャートが保持されます。ただし、PPT と PPTX はすべての機能を同一に表現できるわけではありません。PPTX に相当するレガシー機能がない、またはライブラリでサポートされていない場合は、正規化、除外、または別の表示になることがあります。

アニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、特殊なフォント、VBA マクロが含まれる場合は、変換後のファイルを必ず確認してください。PPTX はマクロ対応形式ではないため、VBA を残す必要がある場合は、適切なマクロ対応ワークフローを使用してください。また、必要なフォントや外部リソースが変換後に開く環境に存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数やコンテンツを検査し、対象ビューアでの外観やスライドショーの動作と比較してください。[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) の呼び出しが成功しただけで、すべてのレガシー機能が正確に PPTX に変換されたとは限りません。

## **PPTX を使用すべき時**

プレゼンテーションを最新の PowerPoint で編集する、Open XML パッケージを扱うシステムとやり取りする、またはバイナリ PPT よりも検査や復元が容易な形式で保管したい場合は PPTX を使用してください。変換後のプレゼンテーションが精度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持します。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/slides/ja/python-java/convert-presentation/) の形式別ガイドラインに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持するとは限らないことに注意してください。

## **オンライン コンバーター**

たまにファイルを変換したり、簡易比較を行う場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーション レベルのエラーハンドリングが必要な場合は、Python via Java API を使用してください。

## **関連記事**

- [PPT と PPTX の比較](/slides/ja/python-java/ppt-vs-pptx/)
- [Python でプレゼンテーションを保存](/slides/ja/python-java/save-presentation/)
- [サポートされているファイル形式](/slides/ja/python-java/supported-file-formats/)
- [Python でプレゼンテーションを開く](/slides/ja/python-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能やサポート外の機能が正確に変換される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、特殊フォントが含まれる場合は、生成されたファイルを必ず確認してください。

**パスワードで保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば変換できます。パスワードが不足または誤っていると、読み込み操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

変換後の PPTX がビューアやワークフローで期待通りに動作し、内容を確認できたことを確認するまで、元の PPT を保持してください。これにより、レガシー機能が異なる形で変換された場合にロールバックできるコピーが残ります。