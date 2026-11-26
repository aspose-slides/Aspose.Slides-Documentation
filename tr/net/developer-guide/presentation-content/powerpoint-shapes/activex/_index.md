---
title: ".NET'te Sunumlarda ActiveX Denetimlerini Yönetme"
linktitle: "ActiveX"
type: docs
weight: 80
url: /tr/net/activex/
keywords:
  - ActiveX
  - ActiveX denetimi
  - ActiveX yönetimi
  - ActiveX ekleme
  - ActiveX değiştirme
  - medya oynatıcı
  - PowerPoint
  - sunum
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında ActiveX metin kutularını ve düğmelerini düzenleyin, denetim ön izlemelerini güncelleyin ve Windows Media Player denetimini yeniden kullanın."
---
## **Giriş**

ActiveX denetimleri, bir PowerPoint slaydına metin kutuları, komut düğmeleri ve medya oynatıcıları gibi etkileşimli öğeler ekler. Aspose.Slides for .NET, bir slaydın denetimlerini [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Bu koleksiyonu bir denetimi düzenlemek, slaytta taşımak veya kaldırmak için kullanın.

## **ActiveX Denetimlerini ve Depolanan Özelliklerini Listele**

Bilgisiz bir şablonu incelemek için, onu okuma amaçlı açın ve her slayttaki denetimler üzerinde döngü yapın. Örnek, slayt numarasını, denetim adını, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), ve [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) içindeki her anahtar‑değer çiftini raporlar. Sunumu denetimleri etkinleştirmeden, olayları veya makroları çağırmadan, değerleri değiştirmeden ya da dosyayı kaydetmeden okur.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
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

Boş bir özellik koleksiyonu `[]` olarak görünür. İkili depolama kullanan denetimler için `Properties` `null` dönebilir ve bu `Properties unavailable` olarak gösterilir. Sadece adlara ihtiyacınız varsa, null kontrolünden sonra [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) kullanın. Rapor, sunumdan elde edilebilen özellikleri listeler. Bir denetim çalışma zamanında ek özellikleri destekleyebilir.

## **ActiveX Denetimlerini Değiştir**

Örnek, ilk slaytta `TextBox1` adlı bir metin kutusu ve `CommandButton1` adlı bir komut düğmesi içeren makro‑etkin bir sunum bekler. Metin kutusu değerini ve düğme başlığını değiştirmek için [denetim özellikleri koleksiyonu](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) kullanır. Her denetimin ayrıca PowerPoint'in etkinleştirmeden önce gösterebileceği statik bir ön izleme vardır. Güncellenmiş metin ve görünümü gösteren bir PNG dosyasını her denetim için sağlayın. Örnek, bu görüntüleri [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) aracılığıyla atar.

Örnek, ilk slayttaki tüm denetimleri [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) özelliğini değiştirerek 100 puan aşağı kaydırır. Düzenlenmiş sunumu PPTM formatında kaydeder, ardından [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) kullanarak o slayttan tüm ActiveX denetimlerini kaldırılmış ikinci bir kopya kaydeder.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **ActiveX Medya Oynatıcı Denetimi Ekle**

Yapılandırılmış bir Windows Media Player denetimini yeniden kullanmak için, ilk slaytında `WindowsMediaPlayer1` adlı bir oynatıcı bulunan bir şablonla başlayın. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) tüm slaytı yeni bir sunuma kopyalar. Örnek, oynatıcının `URL`’sini [özellikler koleksiyonu](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) içinde ayarlar ve klonlanan slaytı çıkışta tek slayt olarak kaydeder. Video harici kalır, bu yüzden oynatıcı oynatma sırasında erişebileceği bir yol seçin.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **SSS**

**Aspose.Slides ActiveX denetimlerini çalıştırmadan koruyabilir mi?**

Evet. Aspose.Slides, denetimlerin özellikleri ve konumları dahil olmak üzere, onları etkinleştirmeden okuyup kaydedebilir.

**ActiveX denetimleri OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, kullanıcıların slayt ile etkileşime girmesini sağlar; örneğin metin girişi yapabilir veya bir düğmeye tıklayabilir. Bir [OLE nesnesi](/slides/tr/net/manage-ole/) ise bir slaydın başka bir uygulama tarafından yönetilen içeriği (örneğin bir Excel çalışma sayfasını) barındırmasına veya ona bağlanmasına izin verir.

**Aspose.Slides ile bir sunumu kaydettikten sonra ActiveX olayları VBA makrolarını tetiklemeye devam edecek mi?**

Sunumu, VBA projesini korumak için PPTM gibi makro‑etkin bir formatta kaydedin. Windows için PowerPoint, güvenlik ayarları hem ActiveX denetimlerine hem de makrolara izin verdiğinde mevcut olay işleyicilerini çalıştırabilir.