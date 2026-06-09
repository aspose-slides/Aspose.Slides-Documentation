---
title: C++'ta PowerPoint Metin Paragraflarını Yönet
linktitle: Paragrafı Yönet
type: docs
weight: 40
url: /tr/cpp/manage-paragraph/
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
- paragrafı görsele
- metni görsele
- paragrafı dışa aktar
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile paragraf biçimlendirmesinde uzmanlaşın—C++'ta PPT, PPTX ve ODP sunumlarında hizalama, boşluk ve stili optimize edin."
---
## **Giriş**

Aspose.Slides, C++'ta PowerPoint metinleri, paragrafları ve bölümleriyle çalışmak için ihtiyaç duyduğunuz tüm arayüzleri ve sınıfları sağlar.

* Aspose.Slides, bir paragrafı temsil eden nesneler eklemenizi sağlayan [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) arayüzünü sunar. Bir `ITextFame` nesnesi bir veya birden fazla paragraf içerebilir (her paragraf bir satır sonu ile oluşturulur).
* Aspose.Slides, bölümleri temsil eden nesneler eklemenizi sağlayan [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) arayüzünü sunar. Bir `IParagraph` nesnesi bir veya birden fazla bölüm (iPortion nesnelerinin koleksiyonu) içerebilir.
* Aspose.Slides, metinleri ve biçimlendirme özelliklerini temsil eden nesneler eklemenizi sağlayan [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) arayüzünü sunar.  

Bir `IParagraph` nesnesi, altındaki `IPortion` nesneleri aracılığıyla farklı biçimlendirme özelliklerine sahip metinleri işleyebilir.

## **Birden Çok Bölüm İçeren Çoklu Paragraflar Ekleme**

Bu adımlar, 3 paragraf ve her paragraf içinde 3 bölüm içeren bir metin çerçevesi eklemeyi gösterir:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansını indeksine göre alın.
3. Slayta bir Dikdörtgen [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ile ilişkili `ITextFrame` nesnesini alın.
5. İki adet [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) nesnesi oluşturun ve bunları [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)`in `IParagraphs` koleksiyonuna ekleyin.
6. Her yeni `IParagraph` için üç adet [IPortion](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportion/) nesnesi (varsayılan paragraf için iki bölüm) oluşturun ve her bir `IPortion` nesnesini ilgili `IParagraph`'ın `IPortion` koleksiyonuna ekleyin.
7. Her bölüm için bir metin belirleyin.
8. `IPortion` nesnesinin sunduğu biçimlendirme özelliklerini kullanarak her bölüme istediğiniz biçimlendirmeyi uygulayın.
9. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, bölümler içeren paragrafların eklenmesi adımlarının bir uygulamasıdır: 

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta eriş
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Dikdörtgene TextFrame ekle
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// İlk paragrafı alıyor
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// İkinci paragrafı ekleme
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Üçüncü paragrafı ekleme
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// PPTX'i diske kaydet
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Paragraf Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve etkili bir şekilde düzenlemenizi ve sunmanızı sağlar. Madde işaretli paragraflar her zaman daha okunaklı ve anlaşılırdır.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansını indeksine göre alın.
3. Seçili slayta bir [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin. 
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. Paragrafın madde işareti `Type` değerini `Symbol` olarak ayarlayın ve madde işareti karakterini belirleyin.
8. Paragrafın `Text` özelliğini ayarlayın.
9. Madde işareti için paragrafın `Indent` değerini belirleyin.
10. Madde işareti için bir renk ayarlayın.
11. Madde işaretinin yüksekliğini ayarlayın.
12. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
13. İkinci paragrafı ekleyin ve 7‑13. adımları tekrar edin.
14. Sunumu kaydedin.

Bu C++ kodu, bir paragraf madde işareti eklemenizi gösterir:

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta eriş
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Dikdörtgene TextFrame ekle
ashp->AddTextFrame(u"");

// Metin çerçevesine erişiliyor
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Metin çerçevesi için Paragraph nesnesi oluştur
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Setting Metni ayarla
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Setting madde işareti girintisini ayarla
paragraph->get_ParagraphFormat()->set_Indent (25);

// Setting madde işareti rengini ayarla
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// set Kendi madde işareti rengini kullanmak için IsBulletHardColor değerini true olarak ayarla
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Setting madde işareti yüksekliğini ayarla
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragrafı metin çerçevesine ekle
txtFrame->get_Paragraphs()->Add(paragraph);

// Creating second paragraph
// Metin çerçevesi için Paragraph nesnesi oluştur
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Setting Metni ayarla
paragraph2->set_Text(u"This is numbered bullet");

// Setting paragraf madde işareti tipini ve stilini ayarla
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Setting madde işareti girintisini ayarla
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Setting madde işareti rengini ayarla
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// set Kendi madde işareti rengini kullanmak için IsBulletHardColor değerini true olarak ayarla
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Setting madde işareti yüksekliğini ayarla
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragrafı metin çerçevesine ekle
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX'i diske kaydet
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Resim Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve etkili bir şekilde düzenlemenizi ve sunmanızı sağlar. Resim paragrafı da okunaklı ve anlaşılırdır.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansını indeksine göre alın.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin. 
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
7. [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) ile resmi yükleyin.
8. Madde işareti türünü [Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) olarak ayarlayın ve resmi belirleyin.
9. Paragrafın `Text` özelliğini ayarlayın.
10. Madde işareti için paragrafın `Indent` değerini belirleyin.
11. Madde işareti için bir renk ayarlayın.
12. Madde işaretinin yüksekliğini ayarlayın.
13. Yeni paragrafı `TextFrame` paragraf koleksiyonuna ekleyin.
14. İkinci paragrafı ekleyin ve önceki adımlara göre işlemi tekrarlayın.
15. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, resim madde işaretlerinin eklenmesi ve yönetilmesini gösterir:

```c++
// Bir PPTX dosyasını temsil eden Presentation sınıfını örnekler
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// İlk slayta erişir
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Madde işaretleri için resmi örnekler
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Autoshape ekler ve ona erişir
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Autoshape'in metin çerçevesine erişir
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Varsayılan paragrafı kaldırır
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Yeni bir paragraf oluşturur
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Paragraf madde işareti stilini ve resmi ayarlar
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Madde işareti yüksekliğini ayarlar
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Paragrafı metin çerçevesine ekler
paragraphs->Add(paragraph);

// Sunumu PPTX dosyası olarak yazar
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Sunumu PPT dosyası olarak yazar
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Çok Düzeyli Madde İşaretlerini Yönetme**

Madde işaretli listeler, bilgileri hızlı ve etkili bir şekilde düzenlemenizi ve sunmanızı sağlar. Çok düzeyli madde işaretleri okunaklı ve anlaşılırdır.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansını indeksine göre alın.
3. Yeni slayta bir [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin. 
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) sınıfı üzerinden ilk paragrafı oluşturun ve derinliği 0 olarak ayarlayın.
7. `Paragraph` sınıfı üzerinden ikinci paragrafı oluşturun ve derinliği 1 olarak ayarlayın.
8. `Paragraph` sınıfı üzerinden üçüncü paragrafı oluşturun ve derinliği 2 olarak ayarlayın.
9. `Paragraph` sınıfı üzerinden dördüncü paragrafı oluşturun ve derinliği 3 olarak ayarlayın.
10. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
11. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, çok düzeyli madde işaretlerinin eklenmesi ve yönetilmesini gösterir:

```c++
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// İlk slayta erişir
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Autoshape ekler ve ona erişir
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Oluşturulan autoshape'in metin çerçevesine erişir
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Varsayılan paragrafı temizler
text->get_Paragraphs()->Clear();

// İlk paragrafı ekler
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Madde işareti seviyesini ayarlar
para1Format->set_Depth(0);

// İkinci paragrafı ekler
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Madde işareti seviyesini ayarlar
para2Format->set_Depth(1);

// Üçüncü paragrafı ekler
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Madde işareti seviyesini ayarlar
para3Format->set_Depth(2);

// Dördüncü paragrafı ekler
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Madde işareti seviyesini ayarlar
para4Format->set_Depth(3);

// Paragrafları koleksiyona ekler
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Sunumu PPTX dosyası olarak yazar
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Özel Numaralı Liste ile Paragraf Yönetimi**

[IBulletFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/) arayüzü, `NumberedBulletStartWith` özelliği ve benzerlerini sunarak özel numaralandırma veya biçimlendirme ile paragrafları yönetmenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Paragrafı içeren slayta erişin.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. Autoshape'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin. 
5. `TextFrame` içindeki varsayılan paragrafı kaldırın.
6. [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) sınıfı üzerinden ilk paragrafı oluşturun ve [NumberedBulletStartWith](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) değerini 2 olarak ayarlayın.
7. `Paragraph` sınıfı üzerinden ikinci paragrafı oluşturun ve `NumberedBulletStartWith` değerini 3 olarak ayarlayın.
8. `Paragraph` sınıfı üzerinden üçüncü paragrafı oluşturun ve `NumberedBulletStartWith` değerini 7 olarak ayarlayın.
9. Yeni paragrafları `TextFrame` paragraf koleksiyonuna ekleyin.
10. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, özel numaralandırma veya biçimlendirme ile paragrafların eklenmesi ve yönetilmesini gösterir:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Oluşturulan autoshape'in metin çerçevesine erişir
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Varsayılan mevcut paragrafı kaldırır
textFrame->get_Paragraphs()->RemoveAt(0);

// İlk liste
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Bir Paragraf İçin İlk Satır Girintisi Ayarlama**

[İlk satır girintisini](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) kontrol etmek için `IParagraphFormat::set_Indent` yöntemini kullanın. Bu yöntem yalnızca paragrafın sol kenarına göre ilk satırı hareket ettirir. Pozitif bir değer ilk satırı sağa kaydırırken, kalan satırlar paragraf gövdesine hizalı kalır.

Tüm paragrafı taşımak istediğinizde `IParagraphFormat::set_MarginLeft` kullanın. Yalnızca ilk satırı taşımak istediğinizde ise `IParagraphFormat::set_Indent` kullanın.

Aşağıdaki örnek, çeşitli `Indent` değerleriyle birkaç paragraf oluşturarak ilk satır girintisinin paragraf düzenine etkisini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Birkaç paragraf oluşturun ve her biri için farklı [Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) değerleri belirleyin.
6. Paragrafları metin çerçevesine ekleyin.
7. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf girintisinin nasıl ayarlanacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafların ilk satır girintisi](first_line_indent.png)

## **Bir Paragraf İçin Asılı Girinti Ayarlama**

Asılı girinti, ilk satırın kalan satırların solunda başladığı bir paragraf düzenidir. Aspose.Slides'te bu etkiyi `IParagraphFormat::set_Indent` yöntemiyle oluşturursunuz. İlk satırı paragraf gövdesine göre sola kaydırmak için girintiyi negatif bir değer olarak ayarlayın.

Uygulamada, `IParagraphFormat::set_MarginLeft` paragraf gövdesinin sol konumunu belirlerken, `IParagraphFormat::set_Indent` bu marjın göre ilk satır konumunu tanımlar. Asılı girinti oluşturmak için pozitif bir `MarginLeft` ve negatif bir `Indent` değeri ayarlayın.

Bu biçimlendirme, bibliyografya, kaynakça, sözlük girdileri ve satırların paragraf gövdesi altında hizalanması gereken diğer paragraflar için faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Hedef slayta erişin.
3. Slayta bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/autoshape/) ekleyin.
4. Şekle boş bir [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) ekleyin ve varsayılan paragrafı kaldırın.
5. Paragraflar oluşturun ve her biri için pozitif bir [MarginLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginleft/) değeri ayarlayın.
6. Asılı girinti etkisi yaratmak için negatif bir [Indent](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_indent/) değeri belirleyin.
7. Paragrafları metin çerçevesine ekleyin.
8. Değiştirilmiş sunumu kaydedin.

Bu kod, bir paragraf için asılı girintinin nasıl ayarlanacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Paragrafların asılı girintisi](hanging_indent.png)

## **Paragraf Sonu Çalışma Özelliklerini Yönetme**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Paragrafı içeren slaytın referansını konumuna göre alın.  
3. Slayta bir dikdörtgen [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.  
4. Dikdörtgene iki paragraf içeren bir [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) ekleyin.  
5. Paragraflar için `FontHeight` ve yazı tipi ayarlayın.  
6. Paragraflar için End (son) özelliklerini ayarlayın.  
7. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu C++ kodu, PowerPoint'teki paragraflar için End (son) özelliklerinin nasıl ayarlanacağını gösterir: 

```c++
// Belgeler dizinine giden yol.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta eriş
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Dikdörtgene TextFrame ekle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// İlk paragrafı ekleme
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// İkinci paragrafı ekleme
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX'i diske kaydet
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **HTML Metnini Paragraflara İçe Aktarma**

Aspose.Slides, HTML metninin paragraflara içe aktarılmasını gelişmiş şekilde destekler.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlgili slaytın referansını indeksine göre alın.
3. Slayta bir [autoshape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ekleyin.
4. `autoshape`[ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin ve ekleyin.
5. `ITextFrame` içindeki varsayılan paragrafı kaldırın.
6. Kaynak HTML dosyasını bir `TextReader` ile okuyun.
7. [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) sınıfını kullanarak ilk paragraf örneğini oluşturun.
8. Okunan `TextReader` içeriğini TextFrame'in [ParagraphCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraphcollection/)'ına ekleyin.
9. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, HTML metinlerinin paragraflara içe aktarılması adımlarının bir uygulamasıdır: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Belgeler dizinine giden yol.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta eriş
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dikdörtgen tipinde bir AutoShape ekle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Varsayılan doldurma rengini sıfırla
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Dikdörtgene TextFrame ekle
ashp->AddTextFrame(u" ");

// Metin çerçevesine erişiliyor
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Paragraflar koleksiyonunu al
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Eklenen metin çerçevesindeki tüm paragrafları temizle
ParaCollection->Clear();

// Akış okuyucu ile HTML dosyasını yüklüyor
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// HTML akış okuyucudan metni metin çerçevesine ekliyor
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Metin çerçevesi için Paragraph nesnesi oluştur
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraf için Portion nesnesi oluştur
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Bölüm biçimini al
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Bölüm için Yazı tipini ayarla
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Yazı tipinin Kalın (Bold) özelliğini ayarla
pf->set_FontBold(NullableBool::True);

// Yazı tipinin İtalik (Italic) özelliğini ayarla
pf->set_FontItalic(NullableBool::True);

// Yazı tipinin Alt çizgi (Underline) özelliğini ayarla
pf->set_FontUnderline(TextUnderlineType::Single);

// Yazı tipinin Yüksekliğini ayarla
pf->set_FontHeight(25);

// Yazı tipinin Rengini ayarla
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX'i diske kaydet
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Paragraf Metnini HTML'ye Dışa Aktarma**

Aspose.Slides, paragraflarda bulunan metinlerin HTML'ye dışa aktarılmasını gelişmiş şekilde destekler.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve istenen sunumu yükleyin.
2. İlgili slaytın referansını indeksine göre alın.
3. HTML'ye dışa aktarılacak metni içeren şekle erişin.
4. Şeklin [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'ine erişin.
5. Bir `StreamWriter` örneği oluşturun ve yeni HTML dosyasını ekleyin.
6. `StreamWriter` için bir başlangıç indeksi belirtin ve istediğiniz paragrafları dışa aktarın.

Bu C++ kodu, PowerPoint paragraf metinlerini HTML'ye dışa aktarmanızı gösterir: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Belgeler dizinine giden yol.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// İstenen sunumu yükle
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Sunumun varsayılan ilk slaytına eriş
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// İstenen indeks
int index = 0;

// Eklenen şekle erişiliyor
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// İlk paragrafı HTML olarak çıkarıyor
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Paragrafların verilerini HTML'ye yazarak paragraf başlangıç indeksi ve kopyalanacak toplam paragraf sayısını sağlar
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Paragrafı Görüntü Olarak Kaydetme**

Bu bölümde, [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) arayüzü ile temsil edilen bir metin paragrafının görüntü olarak nasıl kaydedileceğini gösteren iki örnek incelenecek. Her iki örnek de, paragrafı içeren şeklin görüntüsünü `GetImage` yöntemleriyle almayı, paragrafın şekil içindeki sınırlarını hesaplamayı ve bitmap görüntüsü olarak dışa aktarmayı içerir. Bu yaklaşımlar, PowerPoint sunumlarından belirli metin bölümlerini ayırıp ayrı görüntüler olarak kaydetmenizi sağlar ve çeşitli senaryolarda yeniden kullanılabilir.

Örnek dosyamızın adı **sample.pptx** ve içinde bir slayt bulunuyor; ilk şekil üç paragraf içeren bir metin kutusu.

![Üç paragraf içeren metin kutusu](paragraph_to_image_input.png)

**Örnek 1**

Bu örnekte ikinci paragraf bir görüntü olarak alınır. Bunun için sunumun ilk slaydındaki şeklin görüntüsü elde edilir, ardından şeklin metin çerçevesindeki ikinci paragrafın sınırları hesaplanır. Paragraf daha sonra yeni bir bitmap görüntüsü üzerine çizilir ve PNG formatında kaydedilir. Bu yöntem, belirli bir paragrafı tam boyut ve biçimlendirmesiyle ayrı bir görüntü olarak kaydetmek istediğinizde çok kullanışlıdır.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Şekli bellekte bitmap olarak kaydet.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Sonuç:

![Paragraf görüntüsü](paragraph_to_image_output.png)

**Örnek 2**

Bu örnek, önceki yaklaşıma ölçek faktörleri ekleyerek genişletir. Şekil sunumdan elde edilir ve `2` ölçek faktörüyle görüntülenir. Bu, paragrafı dışa aktarırken daha yüksek çözünürlüklü bir çıktı elde etmenizi sağlar. Paragraf sınırları ölçek dikkate alınarak hesaplanır. Ölçekleme, özellikle yüksek kaliteli baskı malzemeleri gibi daha detaylı bir görüntüye ihtiyaç duyulduğunda faydalıdır.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Şekli bellekte ölçekli bir bitmap olarak kaydet.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Bellekten bir şekil bitmap'i oluştur.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Çıktı görüntüsü için boyutu hesapla (minimum boyut - 1x1 piksel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Paragraf için bir bitmap hazırla.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Paragrafı şekil bitmap'inden paragraf bitmap'ine yeniden çiz.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **SSS**

**Bir metin çerçevesinde satır kırmayı tamamen devre dışı bırakabilir miyim?**

Evet. Metin çerçevesinin kırma yöntemini ([set_WrapText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_wraptext/)) kullanarak kırmayı kapatabilirsiniz; böylece satırlar çerçevenin kenarlarında kırılmaz.

**Belirli bir paragrafın slayt üzerindeki tam sınırlarını nasıl alabilirim?**

Paragrafın (ve hatta tek bir bölümün) sınırlayıcı dikdörtgenini alarak slayt üzerindeki kesin konum ve boyutunu öğrenebilirsiniz.

**Paragraf hizalaması (sol/sağ/ortala/iki yana yasla) nerede kontrol edilir?**

[Alignment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraphformat/set_alignment/) bir paragraf düzeyinde ayardır ve [ParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraphformat/) içinde bulunur; bireysel bölüm biçimlendirmesinden bağımsız olarak tüm paragrafı etkiler.

**Paragrafın sadece bir kısmı (ör. bir kelime) için yazım denetimi dili ayarlayabilir miyim?**

Evet. Dil, bölüm düzeyinde ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/)) ayarlandığından, aynı paragrafta birden fazla dil aynı anda bulunabilir.