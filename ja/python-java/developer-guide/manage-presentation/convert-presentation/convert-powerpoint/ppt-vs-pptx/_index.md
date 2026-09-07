---
title: "違いの理解: PPT と PPTX"
linktitle: PPT と PPTX
type: docs
weight: 10
url: /ja/python-java/ppt-vs-pptx/
keywords:
- PPT と PPTX
- PPT または PPTX
- 従来のフォーマット
- 最新のフォーマット
- バイナリフォーマット
- Office Open XML
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PPT と PPTX の形式、互換性、変換オプションを比較し、Python のコード例も含めています。"
---
## **概要**

PPT と PPTX は、内部構造と機能サポートが異なる PowerPoint プレゼンテーション形式です。PPT は PowerPoint 97–2003 で使用された従来のバイナリ形式です。PPTX は PowerPoint 2007 で導入された Office Open XML 形式です。この記事では、これらの形式を比較し、Aspose.Slides for Python via Java を使用して PPT ファイルを PPTX に変換する方法を示します。

## **PPT とは何ですか？**

[PPT](https://docs.fileformat.com/presentation/ppt/) はプレゼンテーション データをバイナリ構造で保存します。その内容を読み取ったり変更したりするには、その構造を理解できるソフトウェアが必要です。PPT は古いバージョンの PowerPoint とファイルを交換する際に有用ですが、最新のプレゼンテーション機能を表現できる範囲は限定的です。

## **PPTX とは何ですか？**

[PPTX](https://docs.fileformat.com/presentation/pptx/) は Office Open XML に基づいています。PPTX ファイルは XML パーツ、メディア、パーツ間のリレーションシップを含む ZIP パッケージです。この構造により、バイナリ PPT よりも形式の調査や拡張が容易になります。PowerPoint は PowerPoint 2007 以降、デフォルトのプレゼンテーション形式として PPTX を使用しています。

## **PPT と PPTX の比較**

| 項目 | PPT | PPTX |
| --- | --- | --- |
| 内部構造 | バイナリ レコード | XML とメディアを含む ZIP パッケージ |
| 主な互換性要件 | PowerPoint 97–2003 のワークフロー | PowerPoint 2007 以降のワークフロー |
| 新しいプレゼンテーション機能 | サポートが限定的; 一部のコンテンツは簡略化される可能性あり | 新しいオブジェクトやエフェクトを幅広くサポート |
| 推奨使用シナリオ | PPT を必要とするシステムとの交換 | 新規プレゼンテーションおよび継続的な編集 |

形式間の変換は単に拡張子を変更するだけではありません。PPTX のいくつかの機能には PPT に直接対応するものがありません。PowerPoint は MetroBlob データなどの特別な PPT レコードに追加情報を格納し、後で新しいコンテンツを保持できるようにします。古い PowerPoint バージョンではすべてのコンテンツを表示できないため、保存してもプレゼンテーションがすべてのビューアで同じように見える・動作することは保証されません。

Aspose.Slides for Python via Java は、両形式の読み込みと保存のための共通 API を提供します。双方向の変換をサポートしますが、形式の違いや未対応機能により結果が影響を受ける可能性があります。可能な限り PPTX を使用し、PPT に変換したプレゼンテーションは対象ビューアで確認してください。

{{% alert color="info" title="注" %}}

[Aspose.Slides 変換アプリ](https://products.aspose.app/slides/ja/conversion/) を使用して、オンラインで PPT から PPTX、PPTX から PPT の変換結果を比較できます。

{{% /alert %}}

## **Python で PPT を PPTX に変換する方法**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスで PPT ファイルを読み込み、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を指定して呼び出します。Microsoft PowerPoint は不要です。

このサンプルは必要に応じて Java 仮想マシンを起動し、`finally` ブロックでプレゼンテーション リソースを解放します。入力パスと出力パスはご自身のファイル名に置き換えてください。

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

他のサンプルについては、[Python で PPT を PPTX に変換](/slides/ja/python-java/convert-ppt-to-pptx/) を参照してください。逆方向の変換と互換性に関する考慮点は、[Python で PPTX を PPT に変換](/slides/ja/python-java/convert-pptx-to-ppt/) をご覧ください。

## **FAQ**

**エラーなく開くことができるなら、古い PPT のまま残す意味はありますか？**

既存のワークフローで PPT が必要な場合は残して構いません。継続的な編集や新機能の利用を考えるなら、[PPTX への変換](/slides/ja/python-java/convert-ppt-to-pptx/) を検討してください。変換後のプレゼンテーションを確認するまで、元のファイルは保持しておきましょう。

**どのプレゼンテーションを優先的に PPTX に変換すべきですか？**

頻繁に編集または共有されるファイル、複雑な[チャート](/slides/ja/python-java/create-chart/)や[シェイプ](/slides/ja/python-java/shape-manipulations/)を含むもの、または[開く](/slides/ja/python-java/open-presentation/)ときに互換性警告が出るものを優先してください。変換後に外観とスライドショーの動作を確認します。

**PPT と PPTX の間で変換する際にパスワード保護は維持されますか？**

出力の保護が自動的に元と同じになるとは限りません。暗号化されたファイルを読み込むときは必要なパスワードを提供し、出力保護を明示的に設定し、保存したファイルを検証してください。[パスワードで保護されたプレゼンテーション](/slides/ja/python-java/password-protected-presentation/) を参照してください。

**PPTX から PPT に変換すると、一部のエフェクトが消えたり簡略化されたりするのはなぜですか？**

PPT はすべての新しいオブジェクト、プロパティ、エフェクトを表現できません。一部の情報は後で復元できるように保持されますが、古いビューアではすべて表示できません。新機能を保持したい場合は、元の PPTX を残しておいてください。