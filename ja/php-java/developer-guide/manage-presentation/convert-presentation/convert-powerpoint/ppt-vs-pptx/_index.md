---
title: "違いを理解する: PPT と PPTX"
linktitle: "PPT と PPTX"
type: docs
weight: 10
url: /ja/php-java/ppt-vs-pptx/
keywords:
- "PPT と PPTX"
- "PPT または PPTX"
- "レガシー形式"
- "モダン形式"
- "バイナリ形式"
- "最新標準"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Java 経由で PHP 用 Aspose.Slides を使用し、PowerPoint の PPT と PPTX を比較し、形式の違い、メリット、互換性、変換のヒントを探ります。"
---

## **PPT とは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリファイル形式であり、特別なツールなしでは内容を表示することはできません。最初の PowerPoint 97‑2003 バージョンは PPT ファイル形式で動作しましたが、その拡張性は制限されています。

## **PPTX とは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は Office Open XML (ISO 29500:2008-2016, ECMA-376) 標準に基づく新しいプレゼンテーションファイル形式です。PPTX は XML とメディアファイルのアーカイブされたセットです。PPTX 形式は容易に拡張できます。たとえば、新しいチャートタイプやシェイプタイプのサポートを追加するのが簡単で、毎回新しい PowerPoint バージョンで PPTX 形式を変更する必要はありません。PPTX 形式は PowerPoint 2007 以降で使用されています。

## **PPT と PPTX**
PPTX ははるかに広範な機能を提供しますが、PPT は依然としてかなり人気があります。PPT から PPTX への、またはその逆への変換の必要性は非常に高いです。

しかし、古い PPT と新しい PPTX 形式間の変換は、他の Microsoft Office 形式の中で最も複雑な課題です。PPT 形式の仕様は公開されていますが、取り扱いは困難です。PowerPoint は PPT ファイル内に特別なパート (MetroBlob) を作成して、PPTX でサポートされているが PPT 形式ではサポートされず古い PowerPoint バージョンで表示できない情報を格納します。この情報は、最新の PowerPoint バージョンで PPT ファイルが読み込まれるか、PPTX 形式に変換されたときに復元できます。

Aspose.Slides はすべてのプレゼンテーション形式で動作する共通 API を提供します。非常にシンプルな方法で PPT から PPTX、PPTX から PPT への変換が可能です。Aspose.Slides は PPT から PPTX への変換を完全にサポートし、いくつかの制限はありますが PPTX から PPT への変換もサポートします。可能な限り PPTX 形式の使用を推奨します。

{{% alert color="primary" %}} 
オンラインの [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/) で PPT から PPTX、および PPTX から PPT への変換品質を確認してください。
{{% /alert %}} 
```php
  # PPT ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # PPT プレゼンテーションを PPTX 形式で保存する
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
詳しくは [**プレゼンテーション PPT を PPTX に変換する方法**](/slides/ja/php-java/convert-ppt-to-pptx/) をご覧ください。
{{% /alert %}} 

## **FAQ**

**エラーなく開くことができる古いプレゼンテーションを PPT のまま残す意味はありますか？**

プレゼンテーションが確実に開き、共同作業や新機能を必要としない場合は、PPT のまま残すことができます。しかし、将来の互換性と拡張性を考慮すると、[convert to PPTX](/slides/ja/php-java/convert-ppt-to-pptx/) の方が望ましいです：この形式はオープンな OOXML 標準に基づいており、最新のツールでより容易にサポートされます。

**どのファイルを優先的に PPTX に変換すべきか、どのように判断すればよいですか？**

最初に変換すべきプレゼンテーションは、次の条件を満たすものです：複数のユーザーが編集している、複雑な[charts](/slides/ja/php-java/create-chart/)や[shapes](/slides/ja/php-java/shape-manipulations/)を含む、外部コミュニケーションで使用されている、または[opened](/slides/ja/php-java/open-presentation/)際に警告が出るものです。

**PPT から PPTX、そして再び PPT に変換した際にパスワード保護は保持されますか？**

パスワードの有無は、使用するツールが正しい変換と暗号化をサポートしている場合にのみ引き継がれます。より確実なのは、[remove protection](/slides/ja/php-java/password-protected-presentation/) で保護を解除し、[convert](/slides/ja/php-java/convert-ppt-to-pptx/) してから、セキュリティポリシーに従って再度保護を適用することです。

**PPTX を PPT に戻すと、一部のエフェクトが消えたり簡略化されたりするのはなぜですか？**

PPT は一部の新しいオブジェクトやプロパティをサポートしていないためです。PowerPoint やツールは、この情報の「トレース」を特別なブロックに保存して後で復元できるようにしますが、古いバージョンの PowerPoint ではそれらを表示できません。