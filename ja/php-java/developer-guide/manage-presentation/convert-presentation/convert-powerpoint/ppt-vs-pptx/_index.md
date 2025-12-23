---
title: "違いを理解する: PPT と PPTX"
linktitle: "PPT と PPTX"
type: docs
weight: 10
url: /ja/php-java/ppt-vs-pptx/
keywords:
- "PPT と PPTX"
- "PPT または PPTX"
- "レガシーフォーマット"
- "最新フォーマット"
- "バイナリフォーマット"
- "最新標準"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Java 経由で PHP 用 Aspose.Slides を使用し、PowerPoint の PPT と PPTX を比較し、フォーマットの違い、利点、互換性、変換のヒントを探ります。"
---

## **PPT とは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) はバイナリファイル形式であり、特別なツールがない限り内容を表示することはできません。最初の PowerPoint 97‑2003 バージョンは PPT ファイル形式を使用していましたが、拡張性は制限されています。

## **PPTX とは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) は Office Open XML (ISO 29500:2008-2016, ECMA-376) 標準に基づく新しいプレゼンテーション ファイル形式です。PPTX は XML とメディア ファイルのアーカイブされたセットです。PPTX 形式は容易に拡張可能で、たとえば新しいチャート タイプやシェイプ タイプへの対応を、毎回 PowerPoint の新バージョンで PPTX 形式を変更せずに追加できます。PPTX 形式は PowerPoint 2007 以降で使用されます。

## **PPT と PPTX の比較**
PPTX ははるかに多機能ですが、PPT も依然として非常に人気があります。PPT から PPTX への変換、またはその逆の変換が求められるケースは多くあります。

しかし、古い PPT と新しい PPTX 形式間の変換は、他の Microsoft Office 形式と比べても最も複雑な課題です。PPT 形式の仕様は公開されていますが、実際に扱うのは難しいです。PowerPoint は PPT ファイル内に特殊な部分 (MetroBlob) を作成して、PPTX が持つが PPT ではサポートされない情報を保存できます。この情報は、最新の PowerPoint バージョンで PPT ファイルを読み込むか PPTX 形式に変換したときに復元されます。

Aspose.Slides はすべてのプレゼンテーション形式を扱う共通インターフェイスを提供します。PPT から PPTX、PPTX から PPT への変換を非常にシンプルに行えます。Aspose.Slides は PPT から PPTX への変換を完全にサポートし、PPTX から PPT への変換も一定の制限のもとでサポートしています。可能な限り PPTX 形式の使用を推奨します。

{{% alert color="primary" %}} 
PPT から PPTX、そして PPTX から PPT への変換品質を、オンラインの[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)で確認してください。
{{% /alert %}} 
```php
  # PPT ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # PPT プレゼンテーションを PPTX 形式で保存します
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
さらに詳しくは[**プレゼンテーション PPT を PPTX に変換する方法**.](/slides/ja/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **よくある質問**

**古いプレゼンテーションをエラーなく開くことができるなら、PPT のままで保持する意味はありますか？**  
プレゼンテーションが確実に開き、共同作業や新機能が不要であれば PPT のままでも構いません。しかし、将来の互換性と拡張性を考えると、[PPTX に変換する](/slides/ja/php-java/convert-ppt-to-pptx/)ことをお勧めします。PPTX はオープンな OOXML 標準に基づいており、最新ツールでのサポートが容易です。

**どのファイルを優先的に PPTX に変換すべきか、判断する基準はありますか？**  
まず、複数のユーザーが編集しているプレゼンテーション、複雑な[チャート](/slides/ja/php-java/create-chart/)/[シェイプ](/slides/ja/php-java/shape-manipulations/)を含むもの、外部コミュニケーションで使用されるもの、または[開く](/slides/ja/php-java/open-presentation/)際に警告が出るものを優先的に変換してください。

**PPT から PPTX、そして再度 PPT に戻す際にパスワード保護は保持されますか？**  
パスワードは正しい変換と暗号化サポートがあるツールでのみ引き継がれます。一般的には、[保護を解除](/slides/ja/php-java/password-protected-presentation/)し、[変換](/slides/ja/php-java/convert-ppt-to-pptx/)した後、セキュリティポリシーに従って再度保護を設定する方が確実です。

**PPTX を PPT に戻すと、一部のエフェクトが消えたり簡略化されたりするのはなぜですか？**  
PPT は新しいオブジェクトやプロパティをサポートしていないためです。PowerPoint やツールはこの情報を特殊ブロックに「痕跡」として保存できますが、古いバージョンの PowerPoint ではそれらを描画できません。