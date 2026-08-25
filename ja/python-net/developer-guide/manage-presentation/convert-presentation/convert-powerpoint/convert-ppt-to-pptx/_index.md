---
title: PythonでPPTをPPTXに変換する
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/python-net/convert-ppt-to-pptx/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTからPPTXへ
- PPTをPPTXとして保存
- PPTをPPTXにエクスポート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の例、エラーハンドリング、忠実度に関する注意点を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Python via .NET は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスで読み込み、[Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) を [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) とともに呼び出します。`with` ステートメントはブロックが終了したときにプレゼンテーションを破棄し、リソースを解放します。

```python
import aspose.slides as slides

# レガシー PPT プレゼンテーションを読み込む。
with slides.Presentation("presentation.ppt") as presentation:
    # プレゼンテーションを PPTX 形式で保存する。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

ファイル拡張子だけでは出力形式は選択されません。出力形式は [SaveFormat.PPTX](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) 引数で指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを異なるものにしてください。

## **複数の PPT ファイルを変換する**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換に失敗してもバッチの残りは停止しません。

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

本番環境では、例外の全文をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビュー キューに書き込んでください。破損したファイル、必要なパスワードなしで開いたパスワード保護されたファイル、アクセスできないパス、サポートされていないコンテンツは、すべて変換失敗の原因となります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/slides/ja/python-net/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、テーブル、チャートを保持します。しかし、PPT と PPTX はすべての機能を正確に同じ方法で表現しているわけではありません。PPTX に対応するものがないレガシー機能や、ライブラリでサポートされていない機能は、正規化されたり、省略されたり、別の方法で表示されたりすることがあります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、珍しいフォント、VBA マクロが含まれる場合は、必ず確認してください。標準の PPTX ファイルはマクロ有効形式ではないため、VBA を残す必要がある場合は、適切なマクロ有効のワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数やコンテンツの重要な要素を検査し、意図したビューアでの外観やスライドショーの動作と比較してください。成功した [Presentation.save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) 呼び出しが、すべてのレガシー機能が正確に PPTX に変換されたことの証明とみなさないでください。

## **PPTX を使用すべき場面**

現在の PowerPoint バージョンで編集する、Open XML パッケージを扱うシステムとやり取りする、またはレガシーなバイナリ PPT よりも検査や復旧が容易な形式で保存する場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、またはその他の出力形式が必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持すると仮定せずに、[Convert Presentations to Multiple Formats](/slides/ja/python-net/convert-presentation/) の形式別ガイドラインを利用してください。

## **オンラインコンバータ**

たまにファイルを変換したり、すばやく比較したりする場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換、バッチ処理、またはアプリケーションレベルのエラーハンドリングが必要な場合は、Python API を使用してください。

## **関連記事**

- [PPT と PPTX の比較](/slides/ja/python-net/ppt-vs-pptx/)
- [Python でプレゼンテーションを保存する](/slides/ja/python-net/save-presentation/)
- [サポートされているファイル形式](/slides/ja/python-net/supported-file-formats/)
- [Python でプレゼンテーションを開く](/slides/ja/python-net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールしなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Python via .NET は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを正確に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能やサポートされていない機能が正確に保持される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、珍しいフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば変換できます。パスワードが不足している、または誤っている場合は読み込み操作が失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合のロールバック コピーとして機能します。