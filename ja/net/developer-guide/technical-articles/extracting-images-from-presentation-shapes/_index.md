---
title: .NET でプレゼンテーション シェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 90
url: /ja/net/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- スライドの背景
- シェイプの背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出します（Aspose.Slides for .NET 使用）— 迅速でコードフレンドリーなソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 
画像はシェイプに追加されることが多く、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/)を通じて追加され、これは[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)オブジェクトのコレクションです。 

本記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 
{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを巡回し、次に各シェイプを巡回して画像を特定する必要があります。画像が見つかったら、抽出して新しいファイルとして保存できます。 XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // プレゼンテーションにアクセスします
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // 最初のスライドにアクセスします
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // 最初のスライドにアクセスします Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // 背景画像を取得します  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // 好みの画像フォーマットを設定します 

            ImageType = Backimg.ContentType;
            ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
            Format = GetImageFormat(ImageType);

            String ImagePath = path + "BackImage_";
            Backimg.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "." + ImageType, Format);

        }
        else
        {
            if (sl.LayoutSlide.Background.FillFormat.FillType == FillType.Picture)
            {
                // 背景画像を取得します  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // 好みの画像フォーマットを設定します 

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // 画像を含むシェイプにアクセスします
            IShape sh = sl.Shapes[j];

            if (sh is AutoShape)
            {
                AutoShape ashp = (AutoShape)sh;
                if (ashp.FillFormat.FillType == FillType.Picture)
                {
                    img = ashp.FillFormat.PictureFillFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;

                }
            }

            else if (sh is PictureFrame)
            {
                IPictureFrame pf = (IPictureFrame)sh;
                if (pf.FillFormat.FillType == FillType.Picture)
                {
                    img = pf.PictureFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;
                }
            }

            // 抽出した画像の好みのフォーマットを設定します
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                String ImagePath = path + "Slides\\Image_";
                img.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "_Shape_" + j.ToString() + "." + ImageType, Format);
            }
            ifImageFound = false;
        }
    }
}

public static System.Drawing.Imaging.ImageFormat GetImageFormat(String ImageType)
{
    System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
    switch (ImageType)
    {
        case "jpeg":
            Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            break;

        case "emf":
            Format = System.Drawing.Imaging.ImageFormat.Emf;
            break;

        case "bmp":
            Format = System.Drawing.Imaging.ImageFormat.Bmp;
            break;

        case "png":
            Format = System.Drawing.Imaging.ImageFormat.Png;
            break;

        case "wmf":
            Format = System.Drawing.Imaging.ImageFormat.Wmf;
            break;

        case "gif":
            Format = System.Drawing.Imaging.ImageFormat.Gif;
            break;

    }
    return Format;
}
```


## **FAQ**

**元の画像を切り取りやエフェクト、シェイプ変換なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/)から画像オブジェクトが取得されます。これは、切り取りやスタイル効果を加えていない元のピクセルを意味します。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)オブジェクトを通過し、これらは生データを保持しています。 

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、無差別に保存するとリスクがあります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/)には、異なるシェイプやスライドから参照されている同一のバイナリデータが含まれている場合があります。重複を防ぐには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。 

**プレゼンテーションのコレクション内の特定の画像にリンクされているシェイプをどのように特定できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成します。[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)への参照を見つけたら、その画像を使用しているシェイプを記録してください。 

**添付文書などのOLEオブジェクトに埋め込まれた画像を抽出できますか？**

直接はできません。OLEオブジェクトはコンテナであるためです。まずOLEパッケージ自体を抽出し、別のツールでその内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)を通じて動作しますが、OLEは別のオブジェクトタイプです。