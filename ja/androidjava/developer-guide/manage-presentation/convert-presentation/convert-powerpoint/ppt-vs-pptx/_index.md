---
title: "違いを理解する: PPT と PPTX"
linktitle: PPT と PPTX
type: docs
weight: 10
url: /ja/androidjava/ppt-vs-pptx/
keywords:
- PPT と PPTX
- PPT または PPTX
- 旧式フォーマット
- 最新形式
- バイナリ形式
- 最新標準
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 用 Aspose.Slides で PowerPoint の PPT と PPTX を比較し、フォーマットの違い、利点、互換性、変換のヒントを探ります。"
---

## **PPT とは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリーファイル形式であり、特別なツールなしでは内容を表示できません。最初の PowerPoint 97-2003 バージョンは PPT ファイル形式で動作しましたが、拡張性は制限されています。

## **PPTX とは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は、Office Open XML (ISO 29500:2008-2016、ECMA-376) 標準に基づく新しいプレゼンテーションファイル形式です。PPTX は XML とメディアファイルのアーカイブセットです。PPTX 形式は容易に拡張できます。たとえば、新しいチャートタイプやシェイプタイプへのサポートを追加するのは簡単で、毎回新しい PowerPoint バージョンで PPTX 形式を変更する必要はありません。PPTX 形式は PowerPoint 2007 以降で使用されています。

## **PPT と PPTX**
PPTX ははるかに幅広い機能を提供しますが、PPT は依然として非常に人気があります。PPT から PPTX への、またはその逆への変換の必要性は高く求められています。

ただし、旧 PPT と新 PPTX 形式間の変換は、他の Microsoft Office 形式の中で最も複雑な課題です。PPT 形式の仕様は公開されていますが、取り扱いは困難です。PowerPoint は PPT ファイル内に特別なパーツ (MetroBlob) を作成し、PPT 形式でサポートされていない PPTX の情報を保存できます。この情報は、PPT ファイルが最新の PowerPoint バージョンで読み込まれるか、PPTX 形式に変換されたときに復元されます。

Aspose.Slides はすべてのプレゼンテーション形式を扱う共通インターフェイスを提供します。PPT から PPTX、PPTX から PPT への変換を非常にシンプルに行えます。Aspose.Slides は PPT から PPTX への変換を完全にサポートし、いくつかの制限はありますが PPTX から PPT への変換もサポートしています。可能な限り PPTX 形式の使用を推奨します。

{{% alert color="primary" %}} 
オンラインの[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)で PPT から PPTX、および PPTX から PPT への変換品質を確認してください。
{{% /alert %}} 
```java
// PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// PPT プレゼンテーションを PPTX 形式で保存しています
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
詳しく読む[**How to Convert Presentations PPT to PPTX**.](/slides/ja/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 

## **よくある質問**

**古いプレゼンテーションをエラーなく開くことができる場合、PPT のままで保持する意味はありますか？**

プレゼンテーションが確実に開き、共同作業や新機能を必要としない場合は PPT のままで保持できます。しかし、将来的な互換性と拡張性を考えると、[PPTX に変換](/slides/ja/androidjava/convert-ppt-to-pptx/)する方が良いでしょう。PPTX はオープンな OOXML 標準に基づいており、最新のツールでのサポートが容易です。

**どのファイルを優先的に PPTX に変換すべきか、どのように判断すればよいですか？**

複数人で編集されている、複雑な[チャート](/slides/ja/androidjava/create-chart/)や[シェイプ](/slides/ja/androidjava/shape-manipulations/)を含む、外部コミュニケーションで使用されている、または[開く](/slides/ja/androidjava/open-presentation/)際に警告が出るプレゼンテーションを優先して変換してください。

**PPT から PPTX、またはその逆に変換した際にパスワード保護は保持されますか？**

パスワードは、使用するツールが正しい変換と暗号化をサポートしている場合のみ引き継がれます。より確実なのは、[保護を解除](/slides/ja/androidjava/password-protected-presentation/)し、[変換](/slides/ja/androidjava/convert-ppt-to-pptx/)した後、セキュリティポリシーに従って再度保護を適用することです。

**PPTX を PPT に戻す際に、一部の効果が消えたり簡略化されたりするのはなぜですか？**

PPT は一部の新しいオブジェクトやプロパティをサポートしていないためです。PowerPoint やツールは、これらの情報を特別なブロックに「トレース」として保存し、後で復元できるようにしますが、古いバージョンの PowerPoint ではそれらをレンダリングできません。