---
title: プレゼンテーションシェイプから画像を抽出
linktitle: シェイプからの画像
type: docs
weight: 100
url: /ja/php-java/extracting-images-from-presentation-shapes/
keywords:
- 画像を抽出
- 画像を取得
- スライドの背景
- シェイプの背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出する — 迅速でコードに優しいソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 

画像はシェイプに追加されることが多く、スライドの背景としても頻繁に使用されます。画像オブジェクトは、[ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) を介して追加され、これは[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトのコレクションです。

本記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に調べ、次にすべてのシェイプを順に調べて画像を特定する必要があります。画像が見つかったら、抽出して新しいファイルとして保存できます。 
```php

```


## **FAQ**

**元の画像をトリミングやエフェクト、シェイプ変形なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) から画像オブジェクトが取得されるため、トリミングやスタイリング効果のない元のピクセルが得られます。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) オブジェクトを通じて、元データを保持します。

**多数の画像を一度に保存すると、同一ファイルが重複するリスクはありますか？**

はい、無差別に保存すると発生します。プレゼンテーションの[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) には、異なるシェイプやスライドから参照される同一バイナリデータが含まれることがあります。重複を防ぐには、書き込む前に抽出したデータのハッシュ、サイズ、内容を比較してください。

**プレゼンテーションのコレクションから特定の画像にリンクされているシェイプを判別する方法は？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。つまり、[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) への参照を見つけたら、どのシェイプが使用しているかを記録します。

**OLE オブジェクト内に埋め込まれた画像（例: 添付文書）を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるため、まず OLE パッケージ自体を抽出し、別のツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) を介して機能し、OLE は別のオブジェクトタイプです。