---
title: "PPT と PPTX"
type: docs
weight: 10
url: /ja/nodejs-java/ppt-vs-pptx/
keywords: "PPT と PPTX"
description: "Aspose.Slides における PPT と PPTX の違いについて読んでください。"
---

## **PPTとは何ですか？**

[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリファイル形式であり、特殊なツールなしでは内容を表示できません。最初の PowerPoint 97-2003 バージョンは PPT ファイル形式を使用していましたが、拡張性は限られています。

## **PPTXとは何ですか？**

[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は Office Open XML (ISO 29500:2008-2016, ECMA-376) 標準に基づく新しいプレゼンテーションファイル形式です。PPTX は XML とメディア ファイルのアーカイブセットです。PPTX 形式は容易に拡張できます。たとえば、新しいチャート タイプやシェイプ タイプへのサポートを追加するのは、毎回新しい PowerPoint バージョンで PPTX 形式を変更する必要がなく簡単です。PPTX 形式は PowerPoint 2007 以降で使用されています。

## **PPT と PPTX の比較**

PPTX ははるかに広範な機能を提供しますが、PPT は依然としてかなり人気があります。PPT から PPTX、またはその逆への変換の必要性は非常に高いです。

しかし、古い PPT と新しい PPTX 形式間の変換は、他の Microsoft Office 形式の中で最も複雑な課題です。PPT 形式の仕様は公開されていますが、扱いは困難です。PowerPoint は PPT ファイル内に特別なパーツ (MetroBlob) を作成して、PPT 形式でサポートされず古い PowerPoint バージョンで表示できない PPTX の情報を保存できます。この情報は、最新の PowerPoint バージョンで PPT ファイルが読み込まれるか PPTX 形式に変換されたときに復元できます。

Aspose.Slides はすべてのプレゼンテーション形式を扱う共通クラスを提供します。PPT から PPTX、PPTX から PPT への変換を非常にシンプルに行うことができます。Aspose.Slides は PPT から PPTX への変換を完全にサポートし、いくつかの制限はありますが PPTX から PPT への変換もサポートします。可能な限り PPTX 形式の使用を推奨します。

{{% alert color="primary" %}} 

オンラインの[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)で PPT から PPTX、PPTX から PPT の変換品質を確認してください。

{{% /alert %}} 
```javascript
// PPT ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("PPTtoPPTX.ppt");
try {
    // PPT プレゼンテーションを PPTX 形式で保存します
    pres.save("PPTtoPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
さらに読む [**How to Convert Presentations PPT to PPTX**.](/slides/ja/nodejs-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**古いプレゼンテーションがエラーなく開くのであれば、PPT のままにしておく意味はありますか？**

プレゼンテーションが確実に開き、共同作業や新機能が不要であれば PPT のまま維持できます。ただし、将来の互換性と拡張性を考えると、[PPTX に変換](/slides/ja/nodejs-java/convert-ppt-to-pptx/)する方が良いです。PPTX はオープンな OOXML 標準に基づいており、最新ツールでのサポートが容易です。

**どのファイルを優先的に PPTX に変換すべきか、判断する方法はありますか？**

まず、複数人で編集されているプレゼンテーション、複雑な[チャート](/slides/ja/nodejs-java/create-chart/)/[シェイプ](/slides/ja/nodejs-java/shape-manipulations/)を含むもの、外部コミュニケーションで使用されるもの、または[開く](/slides/ja/nodejs-java/open-presentation/)際に警告が出るものを優先的に変換してください。

**PPT から PPTX、そして戻す際にパスワード保護は保持されますか？**

パスワードの保持は、使用するツールが正しい変換と暗号化をサポートしている場合にのみ可能です。まず[保護を解除](/slides/ja/nodejs-java/password-protected-presentation/)、変換[(/slides/ja/nodejs-java/convert-ppt-to-pptx/)](/slides/ja/nodejs-java/convert-ppt-to-pptx/)、そしてセキュリティ ポリシーに従って再度保護を適用する方が信頼性が高いです。

**PPTX を PPT に戻すと一部のエフェクトが消えたり簡略化されたりするのはなぜですか？**

PPT は一部の新しいオブジェクトやプロパティをサポートしていないためです。PowerPoint やツールはこの情報の「痕跡」を特別なブロックに保存して後で復元できるようにしますが、古いバージョンの PowerPoint ではそれらをレンダリングできません。