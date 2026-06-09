---
title: .NET'te Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/net/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini alma
- şekil alternatif metni
- şekil yerleşim formatları
- SVG olarak şekil
- şekli SVG'ye dönüştürme
- şekli hizalama
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te şekiller oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlarda şekillerle nasıl çalışılacağını açıklar. Bir slaytta şekil bulma, kopyalama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ile sonraki işlem için alternatif metin ayarlama konularını gösterir.

Ayrıca şekiller için yerleşim formatlarına erişme, şekli SVG olarak render etme, slaytta şekilleri hizalama ve yatay ve dikey yansıtma için flip özelliklerini kullanma konularını kapsar. Ek olarak, makale şekil birleştirme, yığılma sırası ve şekil kilitleme hakkında kısa bir SSS içerir.

## **Slaytta Bir Şekil Bulma**
Bu konu, geliştiricilerin bir slaytta belirli bir şekli, dahili Id'sini kullanmadan bulmalarını kolaylaştıran basit bir tekniği açıklayacaktır. PowerPoint Sunum dosyalarının bir slayttaki şekilleri dahili benzersiz Id dışında tanımlamanın bir yolu olmadığını bilmek önemlidir. Geliştiricilerin dahili benzersiz Id'yi kullanarak bir şekil bulması zor görünüyor. Slaytlara eklenen tüm şekillerin bir Alt Metni vardır. Geliştiricilere belirli bir şekil bulmak için alternatif metin kullanmalarını öneriyoruz. Gelecekte değiştirmeyi planladığınız nesneler için alternatif metni tanımlamak amacıyla MS PowerPoint’i kullanabilirsiniz.

İstediğiniz herhangi bir şeklin alternatif metni ayarlandıktan sonra, Aspose.Slides for .NET kullanarak o sunumu açabilir ve bir slayta eklenen tüm şekillerde döngü yapabilirsiniz. Her döngüde, şeklin alternatif metnini kontrol edebilir ve eşleşen alternatif metne sahip şekil, sizin istediğiniz şekil olacaktır. Bu tekniği daha iyi göstermek için, bir slaytta belirli bir şekli bulup o şekli döndüren bir metod oluşturduk, [FindShape](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/findshape/#findshape_1).

```c#
public static void Run()
{
    // Sunum dosyasını temsil eden bir Presentation sınıfı örneği oluştur
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Bulunacak şeklin alternatif metni
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Bir slaytta şekli alternatif metniyle bulmak için metodun uygulanması
public static IShape FindShape(ISlide slide, string alttext)
{
    // Slayt içindeki tüm şekiller üzerinde iterasyon
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Eğer slaytın alternatif metni gerekenle eşleşirse
        // Şekli döndür
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Bir Şekli Kopyalama**
1. `Presentation` sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksini kullanarak alın.  
1. Kaynak slaydın şekil koleksiyonuna erişin.  
1. Sunuma yeni bir slayt ekleyin.  
1. Kaynak slaydın şekil koleksiyonundaki şekilleri yeni slayta kopyalayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir grup şekli slayta ekler.

```c#
// Presentation sınıfını örnekle
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTX dosyasını diske kaydet
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Şekli Kaldırma**
1. `Presentation` sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Belirli AlternativeText'e sahip şekli bulun.  
1. Şekli kaldırın.  
1. Dosyayı diske kaydedin.

```c#
// Presentation nesnesi oluştur
Presentation pres = new Presentation();

// İlk slaytı al
ISlide sld = pres.Slides[0];

// Dikdörtgen tipinde otomatik şekil ekle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Sunumu diske kaydet
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Bir Şekli Gizleme**
1. `Presentation` sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Belirli AlternativeText'e sahip şekli bulun.  
1. Şekli gizleyin.  
1. Dosyayı diske kaydedin.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();

// İlk slaytı al
ISlide sld = pres.Slides[0];

// Dikdörtgen tipinde otomatik şekil ekle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Sunumu diske kaydet
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Şekil Sırasını Değiştirme**
1. `Presentation` sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Bir şekil ekleyin.  
1. Şeklin metin çerçevesine biraz metin ekleyin.  
1. Aynı koordinatlarda başka bir şekil ekleyin.  
1. Şekilleri yeniden sırala.  
1. Dosyayı diske kaydedin.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Interop Şekil Kimliğini Alma**
Aspose.Slides for .NET, UniqueId özelliğine karşılık olarak slayt kapsamında benzersiz bir şekil tanımlayıcısı elde etmeyi sağlayan Interop şekil kimliğini almayı sağlar. OfficeInteropShapeId özelliği IShape arabirimlerine ve Shape sınıfına eklendi. OfficeInteropShapeId özelliği tarafından döndürülen değer, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelir. Aşağıda örnek kod verilmiştir.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Slayt kapsamında benzersiz şekil tanımlayıcısını alıyor
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Bir Şekil İçin Alternatif Metin Ayarlama**
Aspose.Slides for .NET, herhangi bir şeklin AlternateText'ini ayarlamayı sağlar.  
Bir sunumdaki şekiller AlternativeText veya Shape Name özelliğiyle ayırt edilebilir.  
AlternativeText özelliği Aspose.Slides ve Microsoft PowerPoint tarafından okunup ayarlanabilir.  
Bu özelliği kullanarak bir şekle etiket ekleyebilir ve bir şekli kaldırma, gizleme veya slaytta şekilleri yeniden sıralama gibi farklı işlemleri gerçekleştirebilirsiniz.  
Bir şeklin AlternateText'ini ayarlamak için aşağıdaki adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Slayta herhangi bir şekil ekleyin.  
1. Yeni eklenen şekille bazı işlemler yapın.  
1. Şekilleri dolaşarak bir şekil bulun.  
1. AlternativeText'i ayarlayın.  
1. Dosyayı diske kaydedin.

```c#
// PPTX'i temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();

// İlk slaytı al
ISlide sld = pres.Slides[0];

// Dikdörtgen tipinde otomatik şekil ekle
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Sunumu diske kaydet
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Bir Şekil İçin Yerleşim Formatlarına Erişim**
Aspose.Slides for .NET, bir şekil için yerleşim formatlarına erişmek için basit bir API sağlar. Bu makale, yerleşim formatlarına nasıl erişileceğini gösterir.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Bir Şekli SVG Olarak Render Etme**
Artık Aspose.Slides for .NET, bir şekli SVG olarak render etmeyi destekler. WriteAsSvg metodu (ve aşırı yüklemesi) Shape sınıfına ve IShape arabirimine eklenmiştir. Bu metod, şeklin içeriğini bir SVG dosyası olarak kaydetmeye olanak tanır. Aşağıdaki kod parçacığı, slaydın şeklini bir SVG dosyasına dışa aktarmayı gösterir.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Bir Şekli Hizalama**
[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/tr/net/aspose.slides.util/slideutil/methods/alignshapes/index) aşırı yüklenmiş metodu aracılığıyla şunları yapabilirsiniz  

* slide'un kenar boşluklarına göre şekilleri hizalayabilirsiniz. Örnek 1'e bakın.  
* birbirlerine göre şekilleri hizalayabilirsiniz. Örnek 2'ye bakın.  

[ShapesAlignmentType](https://reference.aspose.com/slides/tr/net/aspose.slides/shapesalignmenttype) enumarasyonu mevcut hizalama seçeneklerini tanımlar.

**Örnek 1**

Bu C# kodu, indeksleri 1,2 ve 4 olan şekilleri slaydın üst kenarına hizalamayı gösterir:  
Aşağıdaki kaynak kodu, indeksleri 1,2 ve 4 olan şekilleri slaydın üst kenarı boyunca hizalar.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Örnek 2**

Bu C# kodu, bir koleksiyondaki tüm şekilleri koleksiyonun alt şekline göre hizalamayı gösterir:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Flip Özellikleri**

Aspose.Slides'te, [ShapeFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/) sınıfı, `FlipH` ve `FlipV` özellikleri aracılığıyla şekillerin yatay ve dikey yansıtılmasını kontrol eder. Her iki özellik de [NullableBool](https://reference.aspose.com/slides/tr/net/aspose.slides/nullablebool/) türündedir; `True` bir flip, `False` flip yok ve `NotDefined` varsayılan davranışı kullanmayı gösterir. Bu değerler bir şeklin [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/) üzerinden erişilebilir.  

Flip ayarlarını değiştirmek için, şeklin mevcut konumu ve boyutu, istenen `FlipH` ve `FlipV` değerleri ve dönüş açısı ile yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/frame/) özelliğine atanır ve sunum kaydedildiğinde yansıtma dönüşümleri uygulanır ve çıktıya yazılır.  

Örneğin, aşağıda gösterildiği gibi ilk slaytta varsayılan flip ayarlarıyla tek bir şekil içeren bir sample.pptx dosyamız olduğunu varsayalım.

![Döndürülecek şekil](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut flip özelliklerini alır ve şekli hem yatay hem de dikey olarak döndürür.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Şeklin yatay çevirme özelliğini al.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Şeklin dikey çevirme özelliğini al.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Yatay olarak çevir.
    NullableBool flipV = NullableBool.True; // Dikey olarak çevir.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Döndürülmüş şekil](flipped_shape.png)

## **SSS**

**Bir slaytta şekilleri (birleştirme/kesişim/çıkarma) masaüstü editöründe olduğu gibi birleştirebilir miyim?**  
Yerleşik bir Boolean işlem API'si yoktur. İstediğiniz konturu kendiniz oluşturup (örneğin [GeometryPath](https://reference.aspose.com/slides/tr/net/aspose.slides/geometrypath/) aracılığıyla ortaya çıkan geometriyi hesaplayıp) yeni bir şekil oluşturabilir, isteğe bağlı olarak orijinal şekilleri kaldırabilirsiniz.  

**Bir şeklin her zaman “üstte” kalması için yığılma sırasını (z-order) nasıl kontrol edebilirim?**  
Slaytın [shapes](https://reference.aspose.com/slides/tr/net/aspose.slides/baseslide/shapes/) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Öngörülebilir sonuçlar için tüm diğer slayt değişikliklerinden sonra z-order'ı sabitleyin.  

**PowerPoint'te kullanıcıların şekli düzenlemesini önlemek için bir şekli “kilitleyebilir” miyim?**  
Evet. [şekil düzeyi koruma işaretleri](/slides/tr/net/applying-protection-to-presentation/) (ör. seçim, hareket, yeniden boyutlandırma, metin düzenlemelerini kilitle) ayarlayın. Gerekirse, master veya layout üzerinde de aynı kısıtlamaları uygulayın. Bu, UI seviyesinde bir korumadır, güvenlik özelliği değildir; daha güçlü koruma için [yalnızca okuma önerileri veya şifreler](/slides/tr/net/password-protected-presentation/) gibi dosya seviyesinde sınırlamalar ekleyin.