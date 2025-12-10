---
title: プレゼンテーションのシェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 100
url: /ja/java/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- スライド背景
- シェイプ背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションにおけるシェイプから画像を抽出する Aspose.Slides for Java を使用した、迅速でコードフレンドリーなソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 

画像はシェイプに追加されることが多く、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/)を通じて追加され、これは[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)オブジェクトのコレクションです。 

本記事では、プレゼンテーションに追加された画像を抽出する方法について説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に確認し、さらに各スライド内のすべてのシェイプを走査して画像を特定する必要があります。画像が見つかったら抽出し、新しいファイルとして保存できます。 
```java
    public void extractImages()
    {
        Presentation pres = new Presentation(folderPath + "ExtractImages.pptx");
        com.aspose.slides.IPPImage img = null;
        com.aspose.slides.IPPImage backImage = null;

        int slideIndex = 0;
        String imageType = "";
        boolean ifImageFound = false;
        for (int i = 0; i < pres.getSlides().size(); i++)
        {

            slideIndex++;
            //最初のスライドにアクセス
            ISlide sl = pres.getSlides().get_Item(i);


            //最初のスライドにアクセス Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //バック画像を取得
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //画像を保存
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //バック画像を取得
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //画像を保存
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // 画像を含むシェイプにアクセス
                IShape sh = sl.getShapes().get_Item(j);

                if (sh instanceof IAutoShape)
                {
                    IAutoShape ashp = (IAutoShape) sh;
                    if (ashp.getFillFormat().getFillType() == FillType.Picture)
                    {
                        img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(img);
                        ifImageFound = true;
                    }
                } else if (sh instanceof IPictureFrame)
                {
                    IPictureFrame pf = (IPictureFrame) sh;
                    img = pf.getPictureFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }

                //好みの画像形式を設定
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //画像を保存
                    img.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
                ifImageFound = false;
            }
        }
    }

    private String getImageTType(IPPImage image)
    {
        String imageContentType = image.getContentType();
        imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
        imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
        return imageContentType;
    }

    private String capitalize(String str)
    {
        if (str == null || str.length() <= 1) return str;
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }
```


## **FAQ**

**元の画像をトリミングやエフェクト、シェイプ変形なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--)から画像オブジェクトが取得されます。つまり、トリミングやスタイリング効果が適用されていない元のピクセルです。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)オブジェクトを通じて、元データを取得します。

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、すべてを無差別に保存すると発生します。プレゼンテーションの[image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--)には、異なるシェイプやスライドから参照される同一のバイナリデータが含まれていることがあります。重複を防ぐためには、書き込み前に抽出したデータのハッシュ、サイズ、または内容を比較してください。

**プレゼンテーションのコレクション内の特定の画像にリンクされているシェイプをどのように特定できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。つまり、[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)への参照を見つけたら、どのシェイプがそれを使用しているかを記録します。

**添付ドキュメントなどのOLEオブジェクトに埋め込まれた画像を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるため、まず OLE パッケージ自体を抽出し、別ツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)を介して機能しますが、OLE は別のオブジェクトタイプです。