---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/cpp/examples/elements/text-box/
keywords:
- kod örneği
- metin kutusu
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'da metin kutularıyla çalışın: C++ kullanarak PPT, PPTX ve ODP sunumları için metin ekleme, biçimlendirme, hizalama, kaydırma, otomatik sığdırma ve stil verme."
---
Aspose.Slides'ta bir **metin kutusu**, bir `AutoShape` ile temsil edilir. Neredeyse tüm şekiller metin içerebilir, ancak tipik bir metin kutusunun dolgu ya da kenarlığı yoktur ve yalnızca metni gösterir.

Bu kılavuz, programlı olarak metin kutularını nasıl ekleyeceğinizi, erişeceğinizi ve kaldıracağınızı açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu, dolgu ve kenarlığı olmayan ve biçimlendirilmiş bir metin içeren basit bir `AutoShape`dır. İşte bir tane oluşturmanın yolu:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Bir dikdörtgen şekli oluştur (varsayılan olarak kenarlıklı ve dolu, metin yok).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu gibi görünmesini sağla.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Metin biçimlendirmesini ayarla.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Gerçek metin içeriğini ata.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Not:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape`, metin kutusu olarak işlev görebilir.

## **İçeriğe Göre Metin Kutularına Erişim**

Belirli bir anahtar kelimeyi (ör. "Slide") içeren tüm metin kutularını bulmak için şekiller üzerinde döngü yapın ve metinlerini kontrol edin:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Yalnızca AutoShape'ler düzenlenebilir metin içerebilir.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Eşleşen metin kutusuyla bir şey yap.
            }
        }
    }

    presentation->Dispose();
}
```

## **İçeriğe Göre Metin Kutularını Kaldırma**

Bu örnek, belirli bir anahtar kelimeyi içeren ilk slayttaki tüm metin kutularını bulur ve siler:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **İpucu:** Döngü sırasında koleksiyonu değiştirmeden önce her zaman şekil koleksiyonunun bir kopyasını oluşturun; bu, koleksiyon değiştirme hatalarını önler.