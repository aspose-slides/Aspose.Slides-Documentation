---
title: "違いを理解する: PPT vs PPTX"
linktitle: "PPT と PPTX"
type: docs
weight: 10
url: /ja/androidjava/ppt-vs-pptx/
keywords:
- "PPT と PPTX"
- "PPT または PPTX"
- "レガシーフォーマット"
- "モダンフォーマット"
- "バイナリ形式"
- "モダン標準"
- "PowerPoint"
- "プレゼンテーション"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Java を使用した Android 用 Aspose.Slides で PowerPoint の PPT と PPTX を比較し、フォーマットの違い、利点、互換性、変換のヒントを探ります。"
---

## **PPT とは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリ ファイル形式であり、特殊なツールなしでは内容を表示できません。最初の PowerPoint 97-2003 バージョンは PPT ファイル形式で動作しましたが、拡張性は制限されています。
## **PPTX とは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は Office Open XML (ISO 29500:2008-2016, ECMA-376) 標準に基づく新しいプレゼンテーション ファイル形式です。PPTX は XML とメディア ファイルのアーカイブセットです。PPTX 形式は簡単に拡張できます。たとえば、新しいチャート タイプやシェイプ タイプのサポートを追加する際に、毎回 PPTX 形式を変更する必要はありません。PPTX 形式は PowerPoint 2007 以降で使用されています。
## **PPT と PPTX の比較**
PPTX ははるかに広範な機能を提供しますが、PPT は依然としてかなり人気があります。PPT から PPTX への変換、またはその逆の変換が強く求められています。

ただし、古い PPT と新しい PPTX 形式間の変換は、他の Microsoft Office 形式と比べて最も複雑な課題です。PPT 形式の仕様は公開されていますが、取り扱いは難しいです。PowerPoint は PPT ファイル内に特殊なパーツ (MetroBlob) を作成し、PPTX でサポートされているが PPT 形式ではサポートされていない情報を保存します。この情報は、最新の PowerPoint バージョンで PPT ファイルを開くか、PPTX 形式に変換したときに復元可能です。

Aspose.Slides はすべてのプレゼンテーション形式を扱う共通インターフェイスを提供します。PPT から PPTX、PPTX から PPT への変換を非常にシンプルに行えます。Aspose.Slides は PPT から PPTX への変換を完全にサポートし、PPTX から PPT への変換もいくつかの制限はありますがサポートしています。可能な限り PPTX 形式の使用を推奨します。

{{% alert color="primary" %}} 
PPT から PPTX、PPTX から PPT の変換品質をオンライン [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/) で確認してください。
{{% /alert %}} 
```java
// PPT ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// PPT プレゼンテーションを PPTX 形式で保存する
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
詳しくは [**How to Convert Presentations PPT to PPTX**.](/slides/ja/androidjava/convert-ppt-to-pptx/) をご覧ください。
{{% /alert %}} 

## **FAQ**

**エラーなく開くことができる場合、古い PPT プレゼンテーションをそのまま残す意味はありますか？**

プレゼンテーションが確実に開き、共同作業や新機能が不要であれば PPT のままでも構いません。ただし、将来的な互換性と拡張性を考えると、[PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/) する方が望ましいです。PPTX はオープンな OOXML 標準に基づいており、最新ツールでのサポートが容易です。

**どのファイルを優先的に PPTX に変換すべきか、判断基準はありますか？**

次の条件に該当するプレゼンテーションを優先的に変換してください。複数人で編集されている、複雑な[チャート](/slides/ja/androidjava/create-chart/)/[シェイプ](/slides/ja/androidjava/shape-manipulations/) を含む、外部向けに配布されている、または[開く](/slides/ja/androidjava/open-presentation/) ときに警告が出るものです。

**PPT から PPTX、そして再び PPT に変換した場合、パスワード保護は維持されますか？**

パスワードは正しい変換と暗号化サポートがあるツールを使用した場合にのみ引き継がれます。より確実なのは、[保護を解除](/slides/ja/androidjava/password-protected-presentation/)、[変換](/slides/ja/androidjava/convert-ppt-to-pptx/) してから、セキュリティ ポリシーに従って再度保護を適用することです。

**PPTX を PPT に戻すと、一部のエフェクトが消えたり簡略化されたりするのはなぜですか？**

PPT は新しいオブジェクトやプロパティをサポートしていないためです。PowerPoint やツールはこの情報の「痕跡」を特殊ブロックに保存し、後で復元できるようにしますが、古いバージョンの PowerPoint では表示されません。