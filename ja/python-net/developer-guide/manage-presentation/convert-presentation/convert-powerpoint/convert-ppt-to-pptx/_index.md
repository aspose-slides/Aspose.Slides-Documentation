---
title: Python で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Aspose.Slides を使用して Python でレガシーな PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換、エラー処理、忠実度に関する注意点の例が含まれています。"
---
## **概要**

PPT は従来のバイナリ形式の PowerPoint、PPTX は新しい Open XML 形式です。Aspose.Slides for Python via .NET は Microsoft PowerPoint がなくても PPT ファイルを読み込み、PPTX として保存できます。本記事では単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目を説明します。

## **PPT ファイルを PPTX に変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスでソース ファイルをロードし、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) に [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) を指定して呼び出します。`with` ステートメントはブロック終了時にプレゼンテーションを破棄し、リソースを解放します。

```python
import aspose.slides as slides

# レガシーな PPT プレゼンテーションを読み込む。
with slides.Presentation("presentation.ppt") as presentation:
    # プレゼンテーションを PPTX 形式で保存する。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

ファイル拡張子だけでは出力形式は決まりません。出力形式は [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) 引数で指定します。元の PPT ファイルを残したい場合は、入力パスと出力パスを別々に設定してください。

## **複数の PPT ファイルを変換する**

次のサンプルは 1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換失敗がバッチ全体を停止させることはありません。

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

本番環境では例外の全文をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名をリトライまたはレビュー キューに書き込むようにしてください。破損したファイル、パスワードが必要なファイルをパスワードなしで開こうとした場合、アクセスできないパス、サポートされていないコンテンツなどが変換失敗の原因となります。暗号化されたファイルの読み込みについては [Password-Protected Presentations](/python-net/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスター、レイアウト、テキスト、シェイプ、画像、表、チャートを保持します。ただし、PPT と PPTX はすべての機能を同じ形で表現できるわけではありません。PPTX に対応する機能がないレガシー機能や、ライブラリでサポートされていない機能は正規化、除外、または別の表示になることがあります。

アニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、珍しいフォント、VBA マクロが含まれる場合は、変換後のファイルを必ず確認してください。純粋な PPTX はマクロ有効形式ではないため、VBA を残す必要がある場合はマクロ有効なワークフローを使用します。また、変換後のプレゼンテーションを開くまたはレンダリングする環境に、必要なフォントや外部リソースが揃っているかも確認してください。

重要な文書については、生成された PPTX をプログラムで再度開き、スライド数や主要コンテンツを検査し、意図したビューアでの外観やスライドショー 動作と比較してください。`[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/)` の呼び出しが成功しただけで、すべてのレガシー機能が完全に PPTX にマッピングされたとは限りません。

## **PPTX を使用すべきタイミング**

現在の PowerPoint バージョンで編集する、Open XML パッケージとやり取りするシステムと共有する、またはレガシーなバイナリ PPT よりも検査や復元が容易な形式で保存する場合は PPTX を使用します。変換後のプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、または他の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/python-net/convert-presentation/) の形式別ガイダンスに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持するとは限らないことに留意してください。

## **オンライン コンバータ**

たまに使用するファイルや簡易比較の場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換、バッチ処理、またはアプリケーションレベルのエラーハンドリングが必要な場合は、Python API を使用してください。

## **関連記事**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via .NET は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能や未サポート機能が完全に同等に変換される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、珍しいフォントが含まれる場合は生成ファイルを必ず確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい。ファイルを読み込む際に正しいパスワードを指定すれば変換可能です。パスワードが不足または誤っている場合、読み込みは失敗します。

**変換後に PPT ファイルを削除すべきですか？**

変換後の PPTX を目的のビューアやワークフローで検証するまで、元の PPT を保持してください。レガシー機能が異なる形で変換された場合のロールバック コピーとして役立ちます。