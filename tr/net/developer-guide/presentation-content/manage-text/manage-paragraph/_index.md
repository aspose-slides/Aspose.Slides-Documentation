---
title: PowerPoint Metin Paragraflarını .NET'te Yönetme
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- metin ekle
- paragraf ekle
- metni yönet
- paragrafı yönet
- madde işaretini yönet
- paragraf girintisi
- asılı girinti
- paragraf madde işareti
- numaralı liste
- madde işaretli liste
- paragraf özellikleri
- HTML içe aktar
- metni HTML'ye
- paragrafı HTML'ye
- paragrafı görüntüye
- metni görüntüye
- paragrafı dışa aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile paragraf biçimlendirmeyi ustalaştırın—PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stili C#'ta optimize edin."
---
## **Giriş**

Aspose.Slides, C#'ta PowerPoint metinleri, paragrafları ve bölümleriyle çalışmak için ihtiyacınız olan tüm arabirimleri ve sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneler eklemenizi sağlayan [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) arabirimini sunar. Bir `ITextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bir bölümü temsil eden nesneler eklemenizi sağlayan [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) arabirimini sunar. Bir `IParagraph` nesnesi bir veya birden fazla bölüm (iPortions nesnelerinin koleksiyonu) içerebilir.
* Aspose.Slides, metinleri ve bunların biçimlendirme özelliklerini temsil eden nesneler eklemenizi sağlayan [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) arabirimini sunar. 

Bir `IParagraph` nesnesi, temel `IPortion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Çoklu Bölümler İçeren Çoklu Paragraflar Ekleme**

Bu adımlar, 3 paragraf ve her paragrafta 3 bölüm içeren bir metin çerçevesi eklemenizi gösterir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayta bir Dikdörtgen [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. İlgili [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ile ilişkili ITextFrame'i alın.
5. İki adet [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesnesi oluşturun ve bunları [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/)`in `IParagraphs` koleksiyonuna ekleyin.
6. Her yeni `IParagraph` için üç adet [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) nesnesi oluşturun (varsayılan paragraf için iki Portion nesnesi) ve her `IPortion` nesnesini ilgili `IParagraph`'ın IPortion koleksiyonuna ekleyin.
7. Her bölüm için bazı metinler ayarlayın.
8. Her bölüm için `IPortion` nesnesinin sunduğu biçimlendirme özelliklerini kullanarak tercih ettiğiniz biçimlendirme özelliklerini uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, bölümler içeren paragrafları ekleme adımlarının bir uygulamasıdır:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
using (Presentation pres = new Presentation())
{
    // İlk slayta erişir
    ISlide slide = pres.Slides[0];

    // Bir Dikdörtgen IAutoShape ekler
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape'in TextFrame'ine erişir
    ITextFrame tf = ashp.TextFrame;

    // Farklı metin formatlarına sahip Paragraflar ve Bölümler oluşturur
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Değiştirilen sunumu kaydeder
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Paragraf Madde İşaretlerini Yönetme**
Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar her zaman daha kolay okunur ve anlaşılır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Seçili slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) özelliğine erişin. 
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
8. Paragraf için madde işareti `Type` özelliğini `Symbol` olarak ayarlayın ve madde işareti karakterini belirleyin.
9. Paragrafın `Text` özelliğini ayarlayın.
10. Madde işareti için paragrafın `Indent` özelliğini ayarlayın.
11. Madde işareti için bir renk ayarlayın.
12. Madde işaretinin yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve 7‑13. adımlarda verilen işlemi tekrarlayın.
15. Sunumu kaydedin.

Bu C# kodu, bir paragraf madde işareti eklemeyi gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
using (Presentation pres = new Presentation())
{

    // İlk slayta erişir
    ISlide slide = pres.Slides[0];


    // Autoshape ekler ve ona erişir
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape'in metin çerçevesine erişir
    ITextFrame txtFrm = aShp.TextFrame;

    // Varsayılan paragrafı kaldırır
    txtFrm.Paragraphs.RemoveAt(0);

    // Bir paragraf oluşturur
    Paragraph para = new Paragraph();

    // Paragraf madde işareti stilini ve sembolünü ayarlar
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Paragraf metnini ayarlar
    para.Text = "Welcome to Aspose.Slides";

    // Madde işareti girintisini ayarlar
    para.ParagraphFormat.Indent = 25;

    // Madde işareti rengini ayarlar
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor özelliğini true olarak ayarlayın, kendi madde işareti rengini kullanmak için

    // Madde işareti yüksekliğini ayarlar
    para.ParagraphFormat.Bullet.Height = 100;

    // Paragrafları metin çerçevesine ekler
    txtFrm.Paragraphs.Add(para);

    // İkinci paragrafı oluşturur
    Paragraph para2 = new Paragraph();

    // Paragraf madde işareti tipini ve stilini ayarlar
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Paragraf metnini ekler
    para2.Text = "This is numbered bullet";

    // Madde işareti girintisini ayarlar
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor özelliğini true olarak ayarlayın, kendi madde işareti rengini kullanmak için

    // Madde işareti yüksekliğini ayarlar
    para2.ParagraphFormat.Bullet.Height = 100;

    // Paragrafları metin çerçevesine ekler
    txtFrm.Paragraphs.Add(para2);


    // Değiştirilen sunumu kaydeder
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Resim Madde İşaretlerini Yönetme**
Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resim paragrafları okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) özelliğine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) ile resmi yükleyin.
8. Madde işareti tipini [Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) olarak ayarlayın ve resmi belirleyin.
9. Paragrafın `Text` özelliğini ayarlayın.
10. Madde işareti için paragrafın `Indent` özelliğini ayarlayın.
11. Madde işareti için bir renk ayarlayın.
12. Madde işaretinin yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara göre işlemi tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, resim madde işaretlerini ekleme ve yönetme yöntemini gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
Presentation presentation = new Presentation();

// İlk slayta erişir
ISlide slide = presentation.Slides[0];

// Madde işaretleri için görüntüyü örnekler
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Autoshape ekler ve ona erişir
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Autoshape'in metin çerçevesine erişir
ITextFrame textFrame = autoShape.TextFrame;

// Varsayılan paragrafı kaldırır
textFrame.Paragraphs.RemoveAt(0);

// Yeni bir paragraf oluşturur
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Paragraf madde işareti stilini ve görüntüyü ayarlar
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Madde işareti yüksekliğini ayarlar
paragraph.ParagraphFormat.Bullet.Height = 100;

// Paragrafı metin çerçevesine ekler
textFrame.Paragraphs.Add(paragraph);

// Sunumu PPTX dosyası olarak yazar
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Sunumu PPT dosyası olarak yazar
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Çok Seviyeli Madde İşaretlerini Yönetme**
Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok seviyeli madde işaretleri okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Yeni slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) özelliğine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfını kullanarak ikinci paragraf örneğini oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfını kullanarak üçüncü paragraf örneğini oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfını kullanarak dördüncü paragraf örneğini oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, çok seviyeli madde işaretlerini ekleme ve yönetme yöntemini gösterir:

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler
using (Presentation pres = new Presentation())
{

    // İlk slayta erişir
    ISlide slide = pres.Slides[0];
    
    // Autoshape ekler ve ona erişir
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Oluşturulan autoshape'in metin çerçevesine erişir
    ITextFrame text = aShp.AddTextFrame("");
    
    // Varsayılan paragrafı temizler
    text.Paragraphs.Clear();

    // İlk paragrafı ekler
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Madde işareti seviyesini ayarlar
    para1.ParagraphFormat.Depth = 0;

    // İkinci paragrafı ekler
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Madde işareti seviyesini ayarlar
    para2.ParagraphFormat.Depth = 1;

    // Üçüncü paragrafı ekler
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Madde işareti seviyesini ayarlar
    para3.ParagraphFormat.Depth = 2;

    // Dördüncü paragrafı ekler
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Madde işareti seviyesini ayarlar
    para4.ParagraphFormat.Depth = 3;

    // Paragrafları koleksiyona ekler
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Sunumu PPTX dosyası olarak yazar
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Özel Numaralı Listeyle Paragrafı Yönetme**
[IBulletFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/) arabirimi, [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith) özelliği ve diğer özellikleriyle özel numaralandırma veya biçimlendirme içeren paragrafları yönetmenizi sağlar. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Paragrafı içeren slayta erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) özelliğine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun ve [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith) değerini 2 olarak ayarlayın.
7. `Paragraph` sınıfını kullanarak ikinci paragraf örneğini oluşturun ve `NumberedBulletStartWith` değerini 3 olarak ayarlayın.
8. `Paragraph` sınıfını kullanarak üçüncü paragraf örneğini oluşturun ve `NumberedBulletStartWith` değerini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, özel numaralandırma veya biçimlendirme içeren paragrafları ekleme ve yönetme yöntemini gösterir:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Oluşturulan autoshape'in metin çerçevesine erişir
	ITextFrame textFrame = shape.TextFrame;

	// Varsayılan mevcut paragrafı kaldırır
	textFrame.Paragraphs.RemoveAt(0);

	// İlk liste
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Paragraf için İlk Satır Girintisi Ayarlama**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliğini kullanarak bir paragrafın ilk satır girintisini kontrol edebilirsiniz. Bu özellik yalnızca ilk satırı paragrafın sol kenar boşluğuna göre hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

[Tüm paragrafı taşımak] gerektiğinde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) kullanın. Sadece ilk satırı taşımak istediğinizde ise [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) kullanın.

Aşağıdaki örnek, çeşitli `Indent` değerleriyle birkaç paragraf oluşturarak ilk satır girintisinin paragraf düzenine etkisini gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgensel bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birçok paragraf oluşturun ve her biri için farklı [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf girintisini nasıl ayarlayacağınızı gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

## **Paragraf için Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliğiyle oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Pratikte, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) paragraf gövdesinin sol konumunu belirler, [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) ise ilk satırın bu kenar boşluğuna göre konumunu tanımlar. Asılı girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografiler, referanslar, sözlük girişleri ve sarmalanmış satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgensel bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf için asılı girinti nasıl ayarlanır gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragraf Sonu Çalıştırma Özelliklerini Yönetme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Paragrafı içeren slaydın referansını konumuna göre alın.
1. Slayta bir dikdörtgen [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
1. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) ekleyin.
1. Paragraflar için `FontHeight` ve yazı tipi ayarlayın.
1. Paragraflar için End (son) özelliklerini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu C# kodu, PowerPoint'te paragraflar için End (son) özelliklerini nasıl ayarlayacağınızı gösterir:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML Metnini Paragraflara İçe Aktarma**
Aspose.Slides, HTML metnini paragraflara içe aktarmak için geliştirilmiş bir destek sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) ekleyin ve ona erişin.
5. `ITextFrame` içindeki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir TextReader ile okuyun.
7. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
8. Okunan TextReader'dan gelen HTML dosyası içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/) öğesine ekleyin.
9. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, HTML metinlerini paragraflara içe aktarma adımlarının bir uygulamasıdır:

```c#
// Boş sunum örneği oluşturur
using (Presentation pres = new Presentation())
{
    // Sunumun varsayılan ilk slaytına erişir
    ISlide slide = pres.Slides[0];

    // HTML içeriğini barındıracak AutoShape'i ekler
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Şekle metin çerçevesi ekler
    ashape.AddTextFrame("");

    // Eklenen metin çerçevesindeki tüm paragrafları temizler
    ashape.TextFrame.Paragraphs.Clear();

    // StreamReader kullanarak HTML dosyasını yükler
    TextReader tr = new StreamReader("file.html");

    // HTML stream reader'dan gelen metni metin çerçevesine ekler
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Sunumu kaydeder
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Paragraf Metnini HTML'ye Dışa Aktarma**
Aspose.Slides, paragraflarda bulunan metinleri HTML'ye dışa aktarmak için geliştirilmiş bir destek sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve istediğiniz sunumu yükleyin.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. HTML'ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) özelliğine erişin.
5. Yeni HTML dosyasını eklemek için bir `StreamWriter` örneği oluşturun.
6. StreamWriter'a bir başlangıç indeksi sağlayın ve tercih ettiğiniz paragrafları dışa aktarın.

Bu C# kodu, PowerPoint paragraf metinlerini HTML'ye nasıl dışa aktaracağınızı gösterir:

```c#
// Sunum dosyasını yükler
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Sunumun varsayılan ilk slaytına erişir
    ISlide slide = pres.Slides[0];

    // Gerekli indekse erişir
    int index = 0;

    // Eklenen şekle erişir
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Paragraf başlangıç indeksini ve kopyalanacak paragraf sayısını belirterek paragraf verilerini HTML'ye yazar
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Paragrafı Görüntü Olarak Kaydetme**

Bu bölümde, [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) arabirimiyle temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örnek inceleyeceğiz. Her iki örnek de paragrafı içeren şeklin görüntüsünü [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arabiriminin `GetImage` yöntemleriyle almayı, paragrafın şekil içindeki sınırlarını hesaplamayı ve bunu bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından belirli metin bölümlerini çıkarıp ayrı görüntüler olarak kaydetmenize olanak tanır; bu da çeşitli senaryolarda yeniden kullanım için faydalı olabilir.

Varsayalım ki sample.pptx adlı bir sunum dosyamız var; bir slaytı ve ilk şekli üç paragraf içeren bir metin kutusu.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Örnek 1**

Bu örnekte ikinci paragrafı bir görüntü olarak elde ediyoruz. Bunu yapmak için sunumun ilk slaydındaki şeklin görüntüsünü çıkarır, ardından şeklin metin çerçevesindeki ikinci paragrafın sınırlarını hesaplarız. Paragraf daha sonra yeni bir bitmap görüntüsüne yeniden çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı tam boyutları ve metin biçimlendirmesi korunarak ayrı bir görüntü olarak kaydetmeniz gerektiğinde özellikle yararlıdır.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

**Örnek 2**

Bu örnek, önceki yaklaşımı paragraf görüntüsüne ölçek faktörleri ekleyerek genişletir. Şekil sunumdan çıkarılır ve `2` ölçek faktörüyle bir görüntü olarak kaydedilir. Bu, paragrafı dışa aktarırken daha yüksek çözünürlüklü bir çıktı elde etmenizi sağlar. Paragraf sınırları, ölçeği dikkate alarak hesaplanır. Ölçekleme, özellikle yüksek kaliteli basılı materyallerde kullanılacak daha ayrıntılı bir görüntü gerektiğinde faydalı olabilir.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Metin çerçevesinin kaydırma ayarını ([WrapText](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/wraptext/)) kullanarak kaydırmayı kapatabilirsiniz; böylece satırlar çerçevenin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak slayt üzerindeki kesin konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortalanmış/iki yana yaslanmış) nerede kontrol edilir?**

[Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/alignment/) bir paragraf düzeyinde ayardır ve [ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/) içinde bulunur; tek tek bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın sadece bir kısmı (ör. bir kelime) için yazım denetimi dili ayarlayabilir miyim?**

Evet. Dil, bölüm düzeyinde ([PortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/)) ayarlandığından, tek bir paragrafta birden çok dil aynı anda bulunabilir.