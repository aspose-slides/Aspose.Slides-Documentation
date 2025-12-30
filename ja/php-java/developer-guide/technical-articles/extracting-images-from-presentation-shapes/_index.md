---
title: プレゼンテーション シェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 100
url: /ja/php-java/extracting-images-from-presentation-shapes/
keywords:
- 画像を抽出する
- 画像を取得する
- スライドの背景
- シェイプの背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションにおけるシェイプから画像を抽出する、Aspose.Slides for PHP via Java を使用した迅速でコードフレンドリーなソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 

画像はしばしばシェイプに追加され、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/)を通じて追加され、これは[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/)オブジェクトのコレクションです。

本記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に確認し、次にすべてのシェイプを順に確認して画像を特定する必要があります。画像が見つかり、または特定されたら、抽出して新しいファイルとして保存できます。 
```php

```


## **FAQ**

**元の画像を切り抜きやエフェクト、シェイプの変換なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/)から画像オブジェクトが取得されます。つまり、切り抜きやスタイル効果のない元のピクセルが得られます。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)オブジェクトを通り、これらは生データを保持しています。

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、すべてを無差別に保存するとそのリスクがあります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/)には、異なるシェイプやスライドから参照される同一のバイナリデータが含まれていることがあります。重複を避けるには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。

**プレゼンテーションのコレクション内の特定の画像にリンクしているシェイプをどのように判別できますか？**

Aspose.Slidesは[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを構築してください。[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)への参照を見つけたら、その画像を使用しているシェイプを記録します。

**添付ドキュメントなどのOLEオブジェクトに埋め込まれた画像を抽出できますか？**

直接はできません。OLEオブジェクトはコンテナであるためです。まずOLEパッケージ自体を抽出し、別ツールでその内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)を介して動作しますが、OLEは別のオブジェクトタイプです。