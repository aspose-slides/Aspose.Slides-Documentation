---
title: C++'ta Sunumlarda Madde İşaretli ve Numaralı Listeleri Yönetme
linktitle: Listeleri Yönet
type: docs
weight: 70
url: /tr/cpp/manage-lists/
keywords:
- madde işareti
- madde işaretli liste
- numaralı liste
- sembol madde işareti
- resim madde işareti
- özel madde işareti
- çok seviyeli liste
- madde işareti oluştur
- madde işareti ekle
- liste ekle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarında madde işaretli, resimli, çok seviyeli ve numaralı listeleri nasıl oluşturup biçimlendireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++, PowerPoint ve OpenDocument sunumlarında madde işaretli ve numaralı listeler oluşturmanıza ve biçimlendirmenize olanak tanır. Bir liste öğesi, madde işareti ayarları paragraf biçimi aracılığıyla kontrol edilen bir paragraftır.

Paragraf düzeyindeki liste ayarlarına erişmek için [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/get_paragraphformat/) yöntemini kullanın. Ana giriş noktası, bir [IBulletFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/) nesnesi döndüren [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_bullet/) yöntemidir. Bu nesne ile madde işareti türünü, sembolü, resmi, rengi, boyutu, numaralandırma stilini ve başlangıç numarasını ayarlayabilirsiniz.

Bu makale aşağıdakileri gösterir:

- özel bir sembolle madde işaretli bir liste oluşturma
- resim madde işareti oluşturma
- paragraf derinliğini ayarlayarak çok seviyeli bir liste oluşturma
- numaralı bir liste oluşturma
- varolan bir sunumda liste biçimlendirmesini inceleme ve değiştirme

## **Madde İşaretli Liste Oluşturma**

Madde işaretli bir liste oluşturmak için, bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) içine [Paragraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraph/) nesneleri ekleyin ve [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) yöntemini [BulletType::Symbol](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın. Ardından, madde işareti görünümünü kontrol etmek için [IBulletFormat::set_Char](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/get_color/) ve [IBulletFormat::set_Height](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_height/) yöntemlerini kullanabilirsiniz.

Aşağıdaki C++ kodu, bir slaytta madde işaretli bir liste nasıl oluşturulacağını gösterir:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Sembol madde işaretleri](symbol_bullets.png)

## **Numaralı Liste Oluşturma**

Ögelerin sırası önemli olduğunda numaralı listeler kullanın. [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) yöntemini [BulletType::Numbered](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın. Ayrıca, [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) ile bir numaralandırma biçimi seçebilir veya listenin 1 yerine başka bir değerden başlaması gerektiğinde [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) yöntemini kullanabilirsiniz.

Aşağıdaki C++ kodu, bir slaytta numaralı bir liste nasıl oluşturulacağını gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Numaralı madde işaretleri](numbered_bullets.png)

## **Resim Madde İşareti Oluşturma**

Aspose.Slides, normal bir madde işareti sembolünü bir görüntüyle değiştirmenize olanak tanır. Resim madde işaretleri, küçük boyutlarda bile okunabilir kalan basit görseller, örneğin simgeler veya küçük şeffaf PNG dosyaları ile en iyi şekilde çalışır.

{{% alert color="primary" %}}
İdeal olarak, normal madde işareti sembolünü bir görüntüyle değiştirmeyi planlıyorsanız, şeffaf bir arka plana sahip basit bir grafik seçmek en iyisidir. Bu tür görseller, özel madde işareti sembolleri olarak iyi çalışır.
{{% /alert %}}

Resim madde işareti oluşturmak için, bir görüntüyü [IPresentation::get_Images](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_images/) yöntemine ekleyin ve döndürülen [IPPImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ippimage/) nesnesini [IBulletFormat::get_Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/get_picture/) yöntemine atayın. Görüntüyü atamadan önce, [IBulletFormat::set_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibulletformat/set_type/) yöntemini [BulletType::Picture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/bullettype/) olarak ayarlayın.

Diyelim ki elimizde bir "image.png" dosyası var:

![Madde işaretleri için bir resim](picture_for_bullets.png)

Aşağıdaki C++ kodu, bir slaytta resim madde işaretleri nasıl oluşturulacağını gösterir:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Resim madde işaretleri](picture_bullets.png)

## **Çok Seviyeli Liste Oluşturma**

Liste öğelerini farklı seviyelere yerleştirmek için [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_depth/) yöntemini kullanın. Seviye 0 en üst seviyedir, seviye 1 onun altında iç içe bir seviyedir ve bu şekilde devam eder.

Aşağıdaki C++ kodu, çok seviyeli bir madde işaretli liste nasıl oluşturulacağını gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Çok seviyeli liste](multilevel_list.png)

## **Varolan Bir Listeyi Değiştirme**

Varolan bir sunumda liste biçimlendirmesini değiştirmek için, hedef paragrafı erişin ve onun [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_bullet/) ayarlarını güncelleyin. Listeleri oluşturmak için kullanılan aynı özellikler, PPT, PPTX veya ODP dosyasından yüklenen listeleri incelemek veya değiştirmek için de kullanılabilir.

Aşağıdaki C++ kodu, bir metin çerçevesindeki ilk paragrafı numaralı liste stilini kullanacak şekilde değiştirir:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Madde işaretli ve numaralı listeler PDF veya görüntülere aktarılabilir mi?**

Evet. Hedef format ilgili metin düzeni ve madde işareti özelliklerini desteklediğinde, Aspose.Slides liste biçimlendirmesini korur.

**Varolan sunumlardaki listeleri düzenleyebilir miyim?**

Evet. Sunumu yükleyin, hedef paragrafı erişin, onun [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/get_bullet/) ayarlarını inceleyin veya güncelleyin ve ardından sunumu kaydedin.

**Listeler Latin dışı metin içerebilir mi?**

Evet. Liste öğesi metni Unicode karakterler içerebilir, bu yüzden çok dilli sunumlarda listeler oluşturabilirsiniz. Sunumda kullanılan yazı tiplerinin ihtiyacınız olan karakterleri desteklediğinden emin olun.