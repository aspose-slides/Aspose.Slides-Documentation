---
title: C++ kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/cpp/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ PowerPoint ve OpenDocument dosyalarında metin kutuları oluşturmayı, düzenlemeyi ve klonlamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından metni metin kutusunun içine koymanız gerekir. Aspose.Slides for C++ [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) arayüzünü sağlar; bu arayüz, içinde metin bulunan bir şekil eklemenize izin verir.

{{% alert title="Info" color="info" %}}

Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [IShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape) arayüzünü de sağlar. Ancak, `IShape` arayüzü aracılığıyla eklenen tüm şekiller metin tutamaz. Fakat [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) arayüzü aracılığıyla eklenen şekiller metin içerebilir. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `IAutoShape` arayüzü üzerinden dönüştürülüp dönüştürülmediğini kontrol etmek ve doğrulamak isteyebilirsiniz. Ancak o zaman `IAutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame) ile çalışabilirsiniz. Bu sayfadaki [Update Text](https://docs.aspose.com/slides/tr/cpp/manage-textbox/#update-text) bölümüne bakın. 

{{% /alert %}}

## **Bir Slaytta Metin Kutusu Oluşturma**

Bir slaytta metin kutusu oluşturmak için bu adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın. 
3. Slayt üzerinde belirli bir konumda `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ile bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesinin referansını alın. 
4. `IAutoShape` nesnesine metin içerecek bir `TextFrame` özelliği ekleyin. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox*
5. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın. 

Bu C++ kodu—yukarıdaki adımların bir uygulaması—bir slayta metin eklemenin nasıl yapılacağını gösterir:

```cpp
// Sunumu örnekler
auto pres = System::MakeObject<Presentation>();

// Sunumdaki ilk slaytı alır
auto sld = pres->get_Slides()->idx_get(0);

// Türü Rectangle olarak ayarlanmış bir AutoShape ekler
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle'a TextFrame ekler
ashp->AddTextFrame(u" ");

// Metin çerçevesine erişir
auto txtFrame = ashp->get_TextFrame();

// Metin çerçevesi için Paragraph nesnesi oluşturur
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraf için Portion nesnesi oluşturur
auto portion = para->get_Portions()->idx_get(0);

// Metni ayarlar
portion->set_Text(u"Aspose TextBox");

// Sunumu diske kaydeder
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Metin Kutusu Şeklini Kontrol Etme**

Aspose.Slides, şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanıyan [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) arayüzünden [get_IsTextBox](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_istextbox/) yöntemini sağlar.

![Text box and shape](istextbox.png)

Bu C++ kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Şunu not edin: [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzündeki `AddAutoShape` yöntemiyle yalnızca bir otos şekil eklediğinizde, otos şeklinin `get_IsTextBox` yöntemi `false` dönecektir. Ancak, otos şekle `AddTextFrame` yöntemi ya da `set_Text` yöntemiyle metin ekledikten sonra, `get_IsTextBox` yöntemi `true` döner.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() false döndürür
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() true döndürür

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() false döndürür
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() true döndürür

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() false döndürür
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() false döndürür

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() false döndürür
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() false döndürür
```

## **Metin Kutusuna Sütunlar Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) ve [set_ColumnSpacing](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) yöntemlerini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) arayüzünden ve [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) sınıfından) sunar. Metin kutusundaki sütun sayısını belirleyebilir ve sütunlar arasındaki boşluğu puan cinsinden ayarlayabilirsiniz. 

Bu C++ kodu, açıklanan işlemi göstermektedir: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Sunumdaki ilk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Türü Rectangle olarak ayarlanmış bir AutoShape ekle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Rectangle'a TextFrame ekle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// TextFrame'in metin biçimini alır
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame içindeki sütun sayısını belirtir
format->set_ColumnCount(3);

// Sütunlar arasındaki boşluğu belirler
format->set_ColumnSpacing(10);

// Sunumu kaydeder
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Metin Çerçevesine Sütunlar Ekleme**
Aspose.Slides for C++, metin çerçevelerine sütun eklemenizi sağlayan [set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) yöntemini ([ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) arayüzünden) sunar. Bu yöntemle, bir metin çerçevesindeki tercih edilen sütun sayısını belirtebilirsiniz. 

Bu C++ kodu, bir metin çerçevesi içinde sütun eklemenin nasıl yapılacağını gösterir:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki veya bir sunumdaki tüm metinleri değiştirme veya güncelleme imkanı sağlar. 

Bu C++ kodu, bir sunumdaki tüm metinlerin güncellendiği veya değiştirildiği bir işlemi gösterir:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Metni değiştirir
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Biçimlendirmeyi değiştirir
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Değiştirilmiş sunumu kaydeder
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Köprü İçeren Metin Kutusu Ekleme** 

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında, kullanıcılar bağlantıyı açmak için yönlendirilir. 

Köprü içeren bir metin kutusu eklemek için bu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumda ilk slayt için bir referans alın. 
3. `ShapeType` `Rectangle` olarak ayarlanmış bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesinin referansını alın.
4. `AutoShape` nesnesine varsayılan metni *Aspose TextBox* olan bir `TextFrame` ekleyin. 
5. `IHyperlinkManager` sınıfının bir örneğini oluşturun. 
6. `TextFrame`'in istediğiniz kısmına ilişkilendirilmiş [set_HyperlinkClick](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) yöntemine `IHyperlinkManager` nesnesini atayın. 
7. Son olarak, PPTX dosyasını `Presentation` nesnesi aracılığıyla yazın. 

Bu C++ kodu—yukarıdaki adımların bir uygulaması—bir slayta köprü içeren bir metin kutusu eklemenin nasıl yapılacağını gösterir:

```cpp
// PPTX'i temsil eden bir Presentation sınıfı örnekler
auto presentation = System::MakeObject<Presentation>();

// Sunumdaki ilk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Şekli AutoShape olarak dönüştürür
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape ile ilişkili ITextFrame özelliğine erişir
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Çerçeveye bazı metinler ekler
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Bölüm metni için Köprüyü ayarlar
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX Sunumunu kaydeder
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Master slaytlarla çalışırken bir metin kutusu ile metin yer tutucu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/cpp/manage-placeholder/), [master](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslide/) stilini/konumunu devralır ve [layouts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan tüm sunumda toplu metin değiştirme nasıl yapabilirim?**

Yinelemeyi, metin çerçevelerine sahip otos-şekillere sınırlayın ve gömülü nesneleri ([charts](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/)) ayrı ayrı koleksiyonlarını gezerek veya bu nesne türlerini atlayarak dışarıda bırakın.