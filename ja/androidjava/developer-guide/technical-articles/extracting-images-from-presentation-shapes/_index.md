---
title: プレゼンテーションのシェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 100
url: /ja/androidjava/extracting-images-from-presentation-shapes/
keywords:
- 画像を抽出
- 画像を取得
- スライド背景
- シェイプ背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、Java で PowerPoint と OpenDocument のプレゼンテーションのシェイプから画像を抽出する — 手軽でコードに優しいソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 

画像はシェイプに追加されることが多く、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/)を通じて追加され、[IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)オブジェクトのコレクションです。

本稿では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に確認し、次に各シェイプを順に確認して画像を特定する必要があります。画像が見つかり、特定できたら、それを抽出して新しいファイルとして保存できます。 
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
            //最初のスライドにアクセスします
            ISlide sl = pres.getSlides().get_Item(i);


            //最初のスライドにアクセスします Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //バック画像を取得します
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //画像を保存します
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //バック画像を取得します
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //画像を保存します
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // 画像を含むシェイプにアクセスします
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

                //優先画像形式を設定します
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //画像を保存します
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

**画像をトリミングやエフェクト、シェイプの変形なしでオリジナルのまま抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--)から画像オブジェクトが取得されます。つまり、トリミングやスタイリング効果が加えられていない元のピクセルが得られます。処理はプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/)オブジェクトを通じて行われ、これらは生データを保持しています。

**一度に多数の画像を保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、無差別に保存すると重複する可能性があります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--)には、異なるシェイプやスライドから参照されている同一のバイナリデータが含まれていることがあります。重複を防ぐためには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。

**プレゼンテーションのコレクション内の特定の画像にリンクされているシェイプをどのように特定できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。つまり、[PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/)への参照を見つけた際に、その画像を使用しているシェイプを記録します。

**添付ドキュメントなどの OLE オブジェクトに埋め込まれた画像を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるためです。まず OLE パッケージ自体を抽出し、別のツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ppimage/)を介して機能しますが、OLE は別のオブジェクトタイプです。