---
title: Python で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX へ
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python でレガシー PPT ファイルを PPTX に変換します。単一ファイルとバッチ変換の Python 例、エラーハンドリング、忠実度に関する注意点を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Python via Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべきポイントを説明します。

各例は必要に応じて Java 仮想マシンを起動し、使用後にプレゼンテーションを解放します。例のパスはご自身のファイルまたはディレクトリのパスに置き換えてください。

## **PPT ファイルを PPTX に変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでソース ファイルを読み込み、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を指定して呼び出します。`finally` ブロックでプレゼンテーションを破棄し、リソースを解放します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# レガシー PPT プレゼンテーションをロードします。
presentation = Presentation("presentation.ppt")
try:
    # プレゼンテーションを PPTX 形式で保存します。
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ファイル拡張子だけでは出力形式は決まりません。[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) 引数が決定します。元の PPT ファイルを残したい場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換する**

次の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換失敗がバッチ全体を中断することはありません。

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

本番環境では、例外内容を完全に記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名をリトライまたはレビュー キューに書き出すことを推奨します。破損したファイル、パスワード保護されたファイルを正しいパスワードなしで開くケース、アクセス不可のパス、サポート外のコンテンツはすべて変換失敗の原因となります。暗号化ファイルの読み込みについては、[Password-Protected Presentations](/slides/ja/python-java/password-protected-presentation/) を参照してください。

## **忠実度とレガシ機能**

変換では通常、スライド、マスター、レイアウト、テキスト、シェイプ、画像、テーブル、チャートが保持されます。しかし、PPT と PPTX はすべての機能を完全に同一に表現できるわけではありません。PPTX に対応するものがないレガシ機能や、ライブラリでサポートされていない機能は正規化、除外、または別の形で表示されることがあります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナーなフォント、VBA マクロが含まれる場合は必ず確認してください。PPTX はマクロ対応形式ではないため、VBA を残す必要がある場合はマクロ対応ワークフローを使用してください。また、変換後のプレゼンテーションを開く環境に必要なフォントや外部リソースが揃っているかも確認してください。

重要な文書については、生成された PPTX をプログラムから再度開き、スライド数や主要コンテンツを検証し、意図したビューアでの外観やスライドショーの動作と比較してください。`[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save)` の呼び出しが成功しただけで、すべてのレガシ機能が完全に PPTX に移行されたとは限りません。

## **PPTX を使用すべき場面**

プレゼンテーションを現在の PowerPoint バージョンで編集する、Open XML パッケージを扱うシステムとやり取りする、またはレガシのバイナリ PPT よりも検査・復元が容易な形式で保存したい場合は PPTX を使用してください。変換後のプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持します。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/slides/ja/python-java/convert-presentation/) の形式別ガイドラインに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持するとは限らないことに留意してください。

## **オンライン コンバータ**

たまに使用するファイルや簡易比較の場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーション レベルのエラー処理が必要な場合は、Python via Java API を使用してください。

## **関連記事**

- [PPT vs PPTX](/slides/ja/python-java/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/ja/python-java/save-presentation/)
- [Supported File Formats](/slides/ja/python-java/supported-file-formats/)
- [Open Presentations in Python](/slides/ja/python-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、レガシ機能や未サポート機能については完全な忠実度は保証できません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、マイナーなフォントが含まれる場合は生成ファイルを必ず確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ロード時に正しいパスワードを指定すれば変換できます。パスワードが欠如または誤っているとロード操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

元の PPT は、重要なビューアやワークフローで PPTX が正しく機能することを確認するまで保持してください。これにより、レガシ機能が異なる形で変換された場合のロールバック コピーが確保できます。