---
title: Bir sunuma tema uygulama
type: docs
weight: 30
url: /tr/net/apply-a-theme-to-a-presentation/
---
## **OpenXML Sunumu**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Sunuma yeni bir tema uygula. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Sunuma yeni bir tema uygula. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Sunum belgesinin sunum bölümünü al.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Mevcut slayt ana bölümü al.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Yeni slayt ana bölümünü al.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Mevcut tema bölümünü kaldır.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Eski slayt ana bölümünü kaldır.

    presentationPart.DeletePart(slideMasterPart);

    // Yeni slayt ana bölümünü içe aktar ve eski ilişki kimliğini yeniden kullan.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Yeni tema bölümüne geç.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Bu örnek için düzen kodunu ekle.

    string defaultLayoutType = "Title and Content";

    // Tüm slaytlarda slayt düzeni ilişkisinin kaldır.

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Her slayt için slayt düzeni tipini belirle.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Eski düzen bölümünü sil.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Yeni düzen bölümünü uygula.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Yeni varsayılan düzen bölümünü uygula.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Slayt düzeni tipini al.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Not: Bu üretim kodunda kullanılıyorsa, null referans kontrolü yap.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Temayı uygulamak için slaytı master ile birlikte klonlamamız gerekir, lütfen aşağıdaki adımları izleyin:

- Kaynak sunumdan slaytın klonlanacağı Presentation sınıfının bir örneğini oluşturun.
- Hedef sunuma slaytın klonlanacağı Presentation sınıfının bir örneğini oluşturun.
- Klonlanacak slaytı ve master slaytı alın.
- Hedef sununun Presentation nesnesi tarafından sağlanan Masters koleksiyonuna başvurarak IMasterSlideCollection sınıfını örnekleyin.
- IMasterSlideCollection nesnesinin sunduğu AddClone yöntemini çağırın ve kaynak PPTX'ten klonlanacak master'ı parametre olarak geçin.
- Hedef sununun Presentation nesnesi tarafından sağlanan Slides koleksiyonuna başvurarak ISlideCollection sınıfını örnekleyin.
- ISlideCollection nesnesinin sunduğu AddClone yöntemini çağırın ve kaynak sunumdan klonlanacak slaytı ve master slaytı parametre olarak geçin.
- Değiştirilmiş hedef sunum dosyasını yazın.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
    Presentation srcPres = new Presentation(presentationFile);

    //Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    Presentation destPres = new Presentation(outputFile);

    //Kaynak sunumdaki slayt koleksiyonundan ISlide'ı oluştur ve
    //master slaytı
    ISlide SourceSlide = srcPres.Slides[0];

    //İstenen master slaytı kaynak sunumdan al ve master koleksiyonuna klonla
    //hedef sunuma
    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    //İstenen master slaytı kaynak sunumdan al ve master koleksiyonuna klonla
    //hedef sunuma
    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    //İstenen slaytı, istenen master ile birlikte kaynak sunumdan al ve hedef sunumdaki slayt koleksiyonunun sonuna ekle
    //koleksiyonuna ekle
    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    //İstenen master slaytı kaynak sunumdan al ve master koleksiyonuna klonla //hedef sunuma
    //Hedef sunumu diske kaydet
    destPres.Save(outputFile, SaveFormat.Pptx);

}
``` 
## **Çalışan Kod Örneğini İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Örnek Kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)