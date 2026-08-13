---
title: "違いを理解する: PPT と PPTX"
linktitle: "PPT と PPTX"
type: docs
weight: 10
url: /ja/java/ppt-vs-pptx/
keywords:
- "PPT と PPTX"
- "PPT または PPTX"
- "レガシーフォーマット"
- "最新フォーマット"
- "バイナリ形式"
- "最新標準"
- "PowerPoint"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "PowerPoint 用 Aspose.Slides for Java で PPT と PPTX を比較し、フォーマットの違い、利点、互換性、変換のヒントを解説します。"
---
## **概要**

この記事では PPT と PPTX フォーマットの違いについて説明します。 PPT は PowerPoint 97–2003 で使用された従来のバイナリ形式であり、 PPTX は柔軟性が高くプレゼンテーション機能の拡張に適した最新の Office Open XML ベースの形式として提示されています。 この記事では、これらの形式間の変換における重要な点（互換性の考慮事項など）を概説し、 Aspose.Slides を使用して変換を実行する方法を示します。 一般に、可能な限り PPTX の使用が推奨されます。

## **PPT とは？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリファイル形式であり、特別なツールがなければ内容を見ることはできません。 最初の PowerPoint 97‑2003 バージョンは PPT ファイル形式を使用していましたが、拡張性は制限されています。

## **PPTX とは？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は Office Open XML (ISO 29500:2008‑2016, ECMA‑376) 標準に基づく新しいプレゼンテーションファイル形式です。 PPTX は XML とメディアファイルのアーカイブセットで構成され、容易に拡張できます。たとえば、新しいチャート種別や図形種別のサポートを追加しても、毎回新しい PowerPoint バージョンで PPTX 形式を変更する必要はありません。 PPTX 形式は PowerPoint 2007 以降で使用されています。

## **PPT と PPTX の比較**
PPTX ははるかに広範な機能を提供しますが、PPT も依然として広く利用されています。 PPT から PPTX、あるいはその逆への変換の必要性は高く求められています。

しかし、旧世代の PPT と新世代の PPTX 形式間の変換は、他の Microsoft Office 形式と比較して最も複雑な課題です。 PPT 形式の仕様は公開されていますが、扱いは容易ではありません。PowerPoint は PPT ファイル内に特別な部分（MetroBlob）を作成して、PPTX でサポートされているが PPT 形式では表示できない情報を格納します。この情報は、最新バージョンの PowerPoint で PPT ファイルを読み込むか PPTX 形式に変換したときに復元できます。

Aspose.Slides はすべてのプレゼンテーション形式を扱う共通インターフェイスを提供します。 PPT から PPTX、PPTX から PPT への変換を非常にシンプルに実行できます。 Aspose.Slides は PPT から PPTX への変換を完全にサポートし、また PPTX から PPT への変換も一部制限付きでサポートします。できる限り PPTX 形式の使用を推奨します。

{{% alert color="info" %}} 
オンラインの[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/ja/conversion/)を使用して、PPT から PPTX への変換および PPTX から PPT への変換の品質を確認してください。 
{{% /alert %}} 

```java
import com.aspose.slides.*;

// PPT ファイルを表す Presentation オブジェクトを作成します
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// PPT プレゼンテーションを PPTX 形式で保存しています
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
詳しくは[**PPT から PPTX へのプレゼンテーション変換方法**.](/slides/ja/java/convert-ppt-to-pptx/)をご覧ください。 
{{% /alert %}} 

## **FAQ**

### エラーなく開くことができるなら、古い PPT のプレゼンテーションを残す意味はありますか？

プレゼンテーションが確実に開き、共同作業や新機能を必要としない場合は、PPT のまま残しても構いません。しかし、将来的な互換性や拡張性を考えると、PPTX に変換する方が望ましいです。PPTX はオープンな OOXML 標準に基づいており、最新のツールでのサポートが容易です。

### どのファイルを優先的に PPTX に変換すべきか、どのように判断できますか？

まず、次の条件に該当するプレゼンテーションを優先的に変換してください：複数人で編集されているもの、複雑な[チャート](/slides/ja/java/create-chart/)/[図形](/slides/ja/java/shape-manipulations/) を含むもの、外部コミュニケーションで使用されているもの、または[開く](/slides/ja/java/open-presentation/)際に警告が出るもの。

### PPT から PPTX、そして PPT に戻す際にパスワード保護は保持されますか？

パスワードは、正しい変換と使用するツールが暗号化をサポートしている場合にのみ引き継がれます。より確実なのは、[保護を解除](/slides/ja/java/password-protected-presentation/)してから変換[/slides/ja/java/convert-ppt-to-pptx/]し、変換後にセキュリティポリシーに従って再度保護を適用することです。

### PPTX を PPT に変換すると、なぜ一部のエフェクトが消えたり簡略化されたりするのでしょうか？

PPT は新しいオブジェクトやプロパティをサポートしていません。PowerPoint やツールはこの情報を後で復元できるように特別なブロックに「痕跡」として保存しますが、古いバージョンの PowerPoint はそれらを描画できません。