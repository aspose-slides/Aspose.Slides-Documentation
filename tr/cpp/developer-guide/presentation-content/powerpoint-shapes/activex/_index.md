---
title: C++ ile Sunumlarda ActiveX Denetimlerini Yönetme
linktitle: ActiveX
type: docs
weight: 80
url: /tr/cpp/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönet
- ActiveX ekle
- ActiveX değiştir
- medya oynatıcı
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, denetim ön izlemelerini güncelleyin ve Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaytına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for C++ bir slaydın denetimlerini [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) aracılığıyla ortaya çıkarır. Bu koleksiyonu bir denetimi düzenlemek, slaytta taşımak veya kaldırmak için kullanın.

## **ActiveX Denetimlerini ve Saklanan Özelliklerini Listeleme**

Tanıdık olmayan bir şablonu incelemek için, onu okuma modunda açın ve her slayttaki denetimler üzerinde yineleyin. Örnek, slayt numarasını, denetim adını, [sınıf kimliği](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), ve [saklanan özellikler](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) içindeki her anahtar‑değer çiftini raporlar. Kontrolleri etkinleştirmeden, olayları ya da makroları tetiklemeden, değerleri değiştirmeden veya dosyayı kaydetmeden sunumu okur.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

`ActiveX.pptm` dosyasından seçilen çıktı bir metin kutusu ve bir komut düğmesi gösterir.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Boş bir özellik koleksiyonu `[]` olarak görünür. İkili depolama kullanan denetimler için `get_Properties` `nullptr` döndürebilir ve bu `Properties unavailable` olarak gösterilir. Yalnızca adlara ihtiyacınız varsa, koleksiyonun varlığını kontrol ettikten sonra [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) kullanın. Rapor, sunumdan erişilebilen özellikleri listeler. Bir denetim çalışma zamanında ek özellikler destekleyebilir.

## **ActiveX Denetimlerini Değiştir**

Örnek, ilk slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi bulunan makro etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [denetim özellikleri koleksiyonu](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) kullanır. Her denetimin ayrıca PowerPoint'in etkinleştirmeden önce görüntüleyebileceği statik bir ön izlemesi vardır. Güncellenmiş metin ve görünümü gösteren bir PNG sağlayın. Örnek bu görüntüleri [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) aracılığıyla atar.

Örnek, ilk slayttaki tüm denetimleri [çerçeve](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) değiştirerek 100 nokta aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) kullanarak o slayttaki tüm ActiveX denetimlerinin kaldırıldığı ikinci bir kopya kaydeder.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **ActiveX Medya Oynatıcı Denetimi Ekle**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL`'sini [özellikler koleksiyonu](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) içinde ayarlar ve klonlanmış slaytı çıktıdaki tek slayt olarak kaydeder. Video harici kalır, bu yüzden oynatıcı oynatma sırasında erişebileceği bir yol seçin.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, onları etkinleştirmeden okuyabilir ve kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, kullanıcıların bir slaytla etkileşimde bulunmasını sağlar; örneğin metin girme ya da bir düğmeye tıklama gibi. Bir [OLE nesnesi](/slides/tr/cpp/manage-ole/) bir slaydın başka bir uygulama tarafından yönetilen içeriği (örneğin bir Excel çalışma sayfası) barındırmasına veya ona bağlanmasına izin verir.

**Aspose.Slides ile bir sunumu kaydettikten sonra ActiveX olayları VBA makrolarını tetiklemeye devam eder mi?**

Sunumu, VBA projesini korumak için PPTM gibi makro etkin bir formatta kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.