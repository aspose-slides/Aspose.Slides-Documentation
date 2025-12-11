---
title: プレゼンテーション シェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 90
url: /ja/cpp/extracting-images-from-presentation-shapes/
keywords:
- 画像を抽出
- 画像を取得
- スライド 背景
- シェイプ 背景
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出する Aspose.Slides for C++ 用の迅速でコードフレンドリーなソリューション。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 
画像はしばしばシェイプに追加され、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)を介して追加され、これは[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)オブジェクトのコレクションです。 
この記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 
{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順にチェックし、次に各シェイプを順にチェックして画像を見つける必要があります。画像が見つかり、特定されたら、それを抽出して新しいファイルとして保存できます。 
```cpp
void Run()
{
    System::String path = u"D:\\Aspose Data\\";
    //プレゼンテーションにアクセスします
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //最初のスライドにアクセスします
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //バック画像を取得します  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //目的の画像形式を設定します
            ImageType = Backimg->get_ContentType();
            ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
            Format = GetImageFormat(ImageType);

            System::String ImagePath = path + u"BackImage_";
            Backimg->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
        }
        else
        {
            if (sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
            {
                //バック画像を取得します  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //目的の画像形式を設定します 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            // 画像を含むシェイプにアクセスします
            System::SharedPtr<IShape> sh = sl->get_Shapes()->idx_get(j);

            if (System::ObjectExt::Is<AutoShape>(sh))
            {
                System::SharedPtr<AutoShape> ashp = System::ExplicitCast<Aspose::Slides::AutoShape>(sh);
                if (ashp->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = ashp->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;

                }
            }
            else if (System::ObjectExt::Is<PictureFrame>(sh))
            {
                System::SharedPtr<IPictureFrame> pf = System::ExplicitCast<Aspose::Slides::IPictureFrame>(sh);
                if (pf->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = pf->get_PictureFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;
                }
            }

            //優先画像形式を設定します
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                System::String ImagePath = path + u"Slides\\Image_";
                img->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"_Shape_" + System::Convert::ToString(j) + u"." + ImageType, Format);
            }

            ifImageFound = false;
        }
    }
}

System::SharedPtr<System::Drawing::Imaging::ImageFormat> GetImageFormat(System::String ImageType)
{
    System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
    {
        const System::String& switch_value_0 = ImageType;
        do {
            if (switch_value_0 == u"jpeg")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
                break;
            }
            if (switch_value_0 == u"emf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Emf();
                break;
            }
            if (switch_value_0 == u"bmp")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Bmp();
                break;
            }
            if (switch_value_0 == u"png")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Png();
                break;
            }
            if (switch_value_0 == u"wmf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Wmf();
                break;
            }
            if (switch_value_0 == u"gif")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Gif();
                break;
            }
        } while (false);
    }

    return Format;
}
```


## **よくある質問**

**元の画像をトリミングや効果、シェイプ変換なしで抽出できますか？**  
はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/)から画像オブジェクトが取得されるため、トリミングやスタイリング効果のない元のピクセルが得られます。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)オブジェクトを通過し、これらは生データを保持しています。  

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**  
はい、無差別にすべて保存すると発生します。プレゼンテーションの[image collection](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/)には、異なるシェイプやスライドから参照される同一のバイナリデータが含まれることがあります。重複を防ぐためには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。  

**プレゼンテーションのコレクション内の特定の画像にリンクされているシェイプをどのように特定できますか？**  
Aspose.Slidesは[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを構築します。[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)への参照を見つけたら、その画像を使用しているシェイプを記録してください。  

**OLE オブジェクト（添付ドキュメントなど）に埋め込まれた画像を抽出できますか？**  
直接はできません。OLE オブジェクトはコンテナであるためです。まず OLE パッケージ自体を抽出し、別のツールでその内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)を介して動作しますが、OLE は別のオブジェクトタイプです。