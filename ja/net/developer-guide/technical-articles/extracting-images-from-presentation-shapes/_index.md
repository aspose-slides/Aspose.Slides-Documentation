---
title: プレゼンテーションの図形から画像を抽出する
type: docs
weight: 90
url: /ja/net/extracting-images-from-presentation-shapes/
keywords: "画像抽出, PowerPoint, PPT, PPTX, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションから画像を抽出する"
---

## **図形から画像を抽出する**

{{% alert color="primary" %}} 
画像はしばしば図形に追加され、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/)を介して追加され、これは[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)オブジェクトのコレクションです。

この記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。
{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に確認し、その後すべての図形を順に確認して画像を特定する必要があります。画像が見つかったら、抽出して新しいファイルとして保存できます。XXX 
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
            // バック画像を取得します  
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // 希望の画像フォーマットを設定します 

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
                // バック画像を取得します  
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // 希望の画像フォーマットを設定します 

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

            // 抽出した画像の希望フォーマットを設定します
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


## **よくある質問**

**元の画像を、切り取りや効果、図形変換なしで抽出できますか？**

はい。図形の画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/)から画像オブジェクトが取得されます。つまり、切り取りやスタイル効果のない元のピクセルです。処理はプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)オブジェクトを順にたどり、そこに生データが保存されています。

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、すべてを無差別に保存すると重複します。プレゼンテーションの[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/)には、異なる図形やスライドから参照される同一のバイナリデータが含まれることがあります。重複を防ぐには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。

**プレゼンテーションのコレクションから特定の画像にリンクしている図形をどのように判別できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)から図形への逆リンクを保持していません。走査中に手動でマッピングを作成します。[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)への参照を見つけたら、その画像を使用している図形を記録してください。

**添付文書などのOLEオブジェクト内に埋め込まれた画像を抽出できますか？**

直接はできません。OLEオブジェクトはコンテナであるためです。まずOLEパッケージ自体を抽出し、別のツールでその内容を解析する必要があります。プレゼンテーションの画像図形は[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/)を介して動作しますが、OLEは別のオブジェクトタイプです。