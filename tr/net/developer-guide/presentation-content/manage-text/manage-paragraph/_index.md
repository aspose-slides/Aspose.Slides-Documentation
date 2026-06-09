---
title: .NET'te PowerPoint Metin Paragraflarını Yönetin
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/net/manage-paragraph/
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
description: "Aspose.Slides for .NET ile paragraf biçimlendirmesinde uzmanlaşın—PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stili C#'ta optimize edin."
---
## **Giriş**

Aspose.Slides, C#'ta PowerPoint metinleri, paragrafları ve bölümleriyle çalışmak için ihtiyaç duyduğunuz tüm arabirimleri ve sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneler eklemenizi sağlayan [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) arabirimini sunar. Bir `ITextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bölümleri temsil eden nesneler eklemenizi sağlayan [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) arabirimini sunar. Bir `IParagraph` nesnesi bir veya birden fazla bölüm içerebilir (iPortions nesnelerinin koleksiyonu).
* Aspose.Slides, metinleri ve biçimlendirme özelliklerini temsil eden nesneler eklemenizi sağlayan [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) arabirimini sunar.

`IParagraph` nesnesi, altında yatan `IPortion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Birden Çok Bölüm İçeren Çoklu Paragraflar Ekleyin**

Bu adımlar, 3 paragraf içeren ve her paragrafın 3 bölüm içerdiği bir metin çerçevesi eklemenizi gösterir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayda bir Dikdörtgen [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. İlgili [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ile ilişkilendirilmiş ITextFrame'i alın.
5. İki [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) nesnesi oluşturun ve bunları [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/)`in `IParagraphs` koleksiyonuna ekleyin.
6. Her yeni `IParagraph` için üç [IPortion](https://reference.aspose.com/slides/tr/net/aspose.slides/iportion/) nesnesi oluşturun (varsayılan Paragraf için iki Portion nesnesi) ve her `IPortion` nesnesini ilgili `IParagraph`'ın IPortion koleksiyonuna ekleyin.
7. Her bölüm için bir metin belirleyin.
8. Her bölüm için `IPortion` nesnesinin sağladığı biçimlendirme özelliklerini kullanarak tercih ettiğiniz biçimlendirme özelliklerini uygulayın.
9. Değiştirilmiş sunumu kaydedin.

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir
using (Presentation pres = new Presentation())
{
    // İlk slayta erişir
    ISlide slide = pres.Slides[0];

    // Bir Dikdörtgen IAutoShape ekler
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape'in TextFrame'ine erişir
    ITextFrame tf = ashp.TextFrame;

    // Farklı metin biçimlerine sahip Paragraflar ve Bölümler oluşturur
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
    // Değiştirilmiş sunumu kaydeder
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Paragraf Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Madde işaretli paragraflar her zaman daha kolay okunur ve anlaşılır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Seçili slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/)’ine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
8. Paragrafın madde işareti `Type` değerini `Symbol` olarak ayarlayın ve madde işareti karakterini belirleyin.
9. Paragrafın `Text` değerini ayarlayın.
10. Madde işareti için paragraf `Indent` değerini ayarlayın.
11. Madde işareti için bir renk ayarlayın.
12. Madde işaretinin yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve adım 7'den 13'e verilen süreci tekrarlayın.
15. Sunumu kaydedin.

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir
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
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor değerini true yaparak kendi madde işareti rengini kullan

    // Madde işareti yüksekliğini ayarlar
    para.ParagraphFormat.Bullet.Height = 100;

    // Paragrafı metin çerçevesine ekler
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
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor değerini true yaparak kendi madde işareti rengini kullan

    // Madde işareti yüksekliğini ayarlar
    para2.ParagraphFormat.Bullet.Height = 100;

    // Paragrafı metin çerçevesine ekler
    txtFrm.Paragraphs.Add(para2);


    // Değiştirilmiş sunumu kaydeder
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Resim Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Resim paragrafları okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayda bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’ine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. Resmi [IPPImage](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) içinde yükleyin.
8. Madde işareti türünü [Picture](https://reference.aspose.com/slides/tr/net/aspose.slides/ippimage/) olarak ayarlayın ve resmi belirleyin.
9. Paragrafın `Text` değerini ayarlayın.
10. Madde işareti için paragraf `Indent` değerini ayarlayın.
11. Madde işareti için bir renk ayarlayın.
12. Madde işareti için bir yükseklik ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara dayanarak süreci tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir
Presentation presentation = new Presentation();

// İlk slayta erişir
ISlide slide = presentation.Slides[0];

// Madde işaretleri için resmi örnekler
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

// Paragraf madde işareti stilini ve resmi ayarlar
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

## **Çok Düzeyli Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve verimli bir şekilde düzenlemenize ve sunmanıza yardımcı olur. Çok düzeyli madde işaretleri okunması ve anlaşılması kolaydır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Yeni slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’ine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfı üzerinden ilk paragraf örneğini oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfı üzerinden ikinci paragraf örneğini oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfı üzerinden üçüncü paragraf örneğini oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfı üzerinden dördüncü paragraf örneğini oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

```c#
// PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir
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

## **Özel Numaralı Listeyle Bir Paragrafı Yönetme**

[IBulletFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/) arabirimi, özel numaralandırma veya biçimlendirme ile paragrafları yönetmenizi sağlayan [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith) özelliği ve diğerlerini sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Paragrafı içeren slayta erişin.
3. Slayda bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’ine erişin.
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfı üzerinden ilk paragraf örneğini oluşturun ve [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/net/aspose.slides/ibulletformat/numberedbulletstartwith) özelliğini 2 olarak ayarlayın.
7. `Paragraph` sınıfı üzerinden ikinci paragraf örneğini oluşturun ve `NumberedBulletStartWith` özelliğini 3 olarak ayarlayın.
8. `Paragraph` sınıfı üzerinden üçüncü paragraf örneğini oluşturun ve `NumberedBulletStartWith` özelliğini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

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

## **Paragraf İçin İlk Satır Girintisini Ayarlama**

Paragrafın ilk satır girintisini kontrol etmek için [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliğini kullanın. Bu özellik yalnızca paragrafın sol kenar boşluğuna göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak gerektiğinde [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) kullanın. Yalnızca ilk satırı taşımak gerektiğinde [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) kullanın.

Aşağıdaki örnek, ilk satır girintisinin paragraf düzenine etkisini göstermek için birkaç paragraf oluşturur ve farklı `Indent` değerleri uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birçok paragraf oluşturun ve bunlar için farklı [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değerleri ayarlayın.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

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

![Paragrafların ilk satır girintisi](first_line_indent.png)

## **Paragraf İçin Asılı Girintiyi Ayarlama**

Asılı girinti, ilk satırın kalan satırların solundan başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) özelliği ile oluşturursunuz. `Indent` değerini negatif yaparak ilk satırı paragraf gövdesine göre sola kaydırırsınız.

Pratikte, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) paragraf gövdesinin sol konumunu, [IParagraphFormat.Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) ise bu kenar boşluğuna göre ilk satırın konumunu tanımlar. Asılı girinti oluşturmak için pozitif bir `MarginLeft` değeri ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografyalar, referanslar, sözlük girdileri ve satırların paragraf gövdesi altına hizalanması gereken diğer paragraflar için kullanışlıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her bir paragraf için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginleft/) değeri ayarlayın.
6. Asılı girinti etkisini oluşturmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/indent/) değeri ayarlayın.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

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

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragraf Sonu Çalıştırma Özelliklerini Yönetme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Paragrafı içeren slaydın referansını konumuna göre alın.
3. Slayda dikdörtgen bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape) ekleyin.
4. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe) ekleyin.
5. Paragraflar için `FontHeight` ve Yazı tipi türünü ayarlayın.
6. Paragraflar için End özelliklerini ayarlayın.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

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

## **Paragraflara HTML Metni İçe Aktarma**

Aspose.Slides, paragraflara HTML metni aktarmak için geliştirilmiş destek sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape) ekleyin.
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/) ekleyin ve ona erişin.
5. `ITextFrame` içindeki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir TextReader ile okuyun.
7. İlk paragraf örneğini [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraph/) sınıfı üzerinden oluşturun.
8. Okunan TextReader içindeki HTML dosyası içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphcollection/)’ına ekleyin.
9. Değiştirilmiş sunumu kaydedin.

```c#
// Boş bir sunum örneği oluşturur
using (Presentation pres = new Presentation())
{
    // Sunumun varsayılan ilk slaytına erişir
    ISlide slide = pres.Slides[0];

    // HTML içeriğini barındırmak için AutoShape ekler
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Şekle metin çerçevesi ekler
    ashape.AddTextFrame("");

    // Eklenen metin çerçevesindeki tüm paragrafları temizler
    ashape.TextFrame.Paragraphs.Clear();

    // HTML dosyasını akış okuyucu ile yükler
    TextReader tr = new StreamReader("file.html");

    // HTML akış okuyucusundan gelen metni metin çerçevesine ekler
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Sunumu kaydeder
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Paragraf Metnini HTML'ye Dışa Aktarma**

Aspose.Slides, metinleri (paragraflarda bulunan) HTML'ye dışa aktarmak için geliştirilmiş destek sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun ve istenen sunumu yükleyin.
2. İlgili slaydın referansına indeksini kullanarak erişin.
3. HTML'ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/)’ine erişin.
5. `StreamWriter` örneği oluşturun ve yeni HTML dosyasını ekleyin.
6. StreamWriter'a başlangıç indeksini sağlayın ve istediğiniz paragrafları dışa aktarın.

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

    // Paragrafların verisini, paragraf başlangıç indeksi ve kopyalanacak paragraf sayısını belirterek HTML'ye yazar
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Paragrafı Görüntü Olarak Kaydet**

Bu bölümde, [IParagraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph/) arabirimi ile temsil edilen bir metin paragrafını görüntü olarak kaydetmeyi gösteren iki örnek inceleyeceğiz. Her iki örnek de paragrafı içeren şeklin görüntüsünü [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arabirimi üzerinden `GetImage` metodlarıyla almayı, paragrafın şekil içindeki sınırlarını hesaplamayı ve bunu bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından metnin belirli bölümlerini ayırıp ayrı görüntüler olarak kaydetmenize imkan tanır; bu da çeşitli senaryolarda ileride kullanım için faydalı olabilir.

Şimdi, sample.pptx adlı bir sunum dosyamız olduğunu ve bir slaytı olduğunu, ilk şeklin üç paragraf içeren bir metin kutusu olduğunu varsayalım.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Örnek 1**

Bu örnekte ikinci paragrafı görüntü olarak elde ediyoruz. Bunu yapmak için sunumun ilk slaytındaki şeklin görüntüsünü çıkarıp, ardından şeklin metin çerçevesindeki ikinci paragrafın sınırlarını hesaplıyoruz. Paragraf daha sonra yeni bir bitmap görüntüsüne yeniden çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı tam boyut ve biçimlendirme korunarak ayrı bir görüntü olarak kaydetmeniz gerektiğinde özellikle kullanışlıdır.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Şekli bellekte bir bitmap olarak kaydeder.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Bellekten bir şekil bitmap'i oluşturur.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// İkinci paragrafın sınırlarını hesaplar.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Çıktı görüntüsü için boyutu hesaplar (minimum boyut - 1x1 piksel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Paragraf için bir bitmap hazırlar.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Paragrafı şekil bitmap'inden paragraf bitmap'ine yeniden çizer.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

![Paragraf görüntüsü](paragraph_to_image_output.png)

**Örnek 2**

Bu örnekte önceki yaklaşımı, paragraf görüntüsüne ölçek faktörleri ekleyerek genişletiyoruz. Şekil sunumdan çıkarılır ve `2` ölçek faktörüyle görüntü olarak kaydedilir. Bu, paragrafı dışa aktarırken daha yüksek çözünürlüklü bir çıktı sağlar. Paragraf sınırları daha sonra ölçeği dikkate alarak hesaplanır. Ölçekleme, özellikle yüksek kaliteli basılı materyallerde kullanım gibi daha ayrıntılı bir görüntü gerektiğinde faydalı olabilir.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Şekli ölçekleme uygulayarak bellekte bir bitmap olarak kaydeder.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Bellekten bir şekil bitmap'i oluşturur.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// İkinci paragrafın sınırlarını hesaplar.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Çıktı görüntüsü için boyutu hesaplar (minimum boyut - 1x1 piksel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Paragraf için bir bitmap hazırlar.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Paragrafı şekil bitmap'inden paragraf bitmap'ine yeniden çizer.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **SSS**

**Metin çerçevesi içinde satır kaydırmayı tamamen devre dışı bırakabilir miyim?**  
Evet. Satır kaydırmayı kapatmak için metin çerçevesinin kaydırma ayarını ([WrapText](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/wraptext/)) kullanın; böylece satırlar çerçevenin kenarlarında bölünmez.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**  
Paragrafın (ve hatta tek bir bölümün) sınırlayan dikdörtgenini alarak slayttaki tam konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**  
[Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/alignment/) [ParagraphFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/paragraphformat/) içinde paragraf seviyesinde bir ayardır; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafta uygulanır.

**Paragrafın sadece bir kısmı (ör. bir kelime) için yazım denetimi dili ayarlayabilir miyim?**  
Evet. Dil, bölüm seviyesinde ([PortionFormat.LanguageId](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/languageid/)) ayarlandığından, tek bir paragrafta birden fazla dil bulunabilir.