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
description: "Aspose.Slides for .NET'in ActiveX'i nasıl kullandığını öğrenin; PowerPoint sunumlarını otomatikleştirir ve geliştirir, geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Introduction**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for .NET, ActiveX denetimlerini yönetmenizi sağlar, ancak bunları yönetmek biraz daha zor ve normal sunum şekillerinden farklıdır. Aspose.Slides for .NET 6.9.0 sürümünden itibaren bileşen, ActiveX denetimlerini yönetmeyi destekler. Şu anda, sunumunuza önceden eklenmiş bir ActiveX denetimine erişebilir ve çeşitli özelliklerini kullanarak öğeyi değiştirebilir veya silebilirsiniz. Unutmayın, ActiveX denetimleri şekil değildir ve sunumun IShapeCollection koleksiyonunun bir parçası değil, ayrı bir IControlCollection koleksiyonunun içindedir. Bu makale, onlarla nasıl çalışılacağını göstermektedir.
## **Modify ActiveX Controls**
Bir slaytta metin kutusu ve basit komut düğmesi gibi basit bir ActiveX denetimini yönetmek için:

1. Presentation sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.
1. İndeksine göre bir slayt referansı alın.
1. IControlCollection koleksiyonuna erişerek slayttaki ActiveX denetimlerine ulaşın.
1. ControlEx nesnesini kullanarak TextBox1 ActiveX denetimine erişin.
1. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi farklı özelliklerini değiştirin.
1. CommandButton1 adlı ikinci erişim denetimine erişin.
1. Düğme başlığını, yazı tipini ve konumunu değiştirin.
1. ActiveX denetimlerinin çerçeve konumlarını kaydırın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod parçacığı, sunum slaytlarındaki ActiveX denetimlerini aşağıda gösterildiği gibi günceller.

```c#
// ActiveX denetimleri içeren sunuma erişiliyor
Presentation presentation = new Presentation("ActiveX.pptm");

// Sunumdaki ilk slayta erişiliyor
ISlide slide = presentation.Slides[0];

// Metin Kutusu metni değiştiriliyor
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Yer tutucu resmi değiştiriliyor. PowerPoint, ActiveX etkinleştirilirken bu resmi değiştirecek, bu yüzden bazen resmi değiştirmeden bırakmak da uygun olur.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Düğme başlığı değiştiriliyor
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // Yer tutucuyu değiştiriliyor
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// ActiveX çerçeveleri 100 puan aşağı kaydırılıyor
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Düzenlenmiş ActiveX denetimleriyle sunumu kaydet
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Şimdi denetimler kaldırılıyor
slide.Controls.Clear();

// Temizlenmiş ActiveX denetimleriyle sunumu kaydediyor
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Add an ActiveX Media Player Control**
ActiveX Medya Oynatıcı denetimini eklemek için aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun ve içinde Media Player ActiveX denetimleri bulunan örnek sunumu yükleyin.
1. Hedef Presentation sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.
1. Şablon sunumdaki Media Player ActiveX denetimine sahip slaytı hedef Presentation'a kopyalayın.
1. Hedef Presentation'daki kopyalanan slayta erişin.
1. IControlCollection koleksiyonuna erişerek slayttaki ActiveX denetimlerine ulaşın.
1. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

```c#
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
Presentation presentation = new Presentation("template.pptx");

// Boş bir sunum örneği oluştur
Presentation newPresentation = new Presentation();

// Varsayılan slaytı kaldır
newPresentation.Slides.RemoveAt(0);

// Media Player ActiveX denetimli slaytı kopyala
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Media Player ActiveX denetimine eriş ve video yolunu ayarla
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Sunumu kaydet
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides, .NET çalışma zamanında çalıştırılamayan ActiveX denetimlerini okuma ve yeniden kaydetme sırasında korur mu?**

Evet. Aspose.Slides, bunları sunumun bir parçası olarak ele alır ve özelliklerini ve çerçevelerini okuyup/ değiştirebilir; denetimlerin kendisinin çalıştırılması, korunmaları için gerekli değildir.

**ActiveX denetimleri, bir sunumdaki OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/net/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Farklı biçimlerde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Dosya Aspose.Slides tarafından değiştirilmişse ActiveX olayları ve VBA makroları çalışır mı?**

Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak olaylar ve makrolar, güvenlik izin verdiğinde yalnızca Windows'taki PowerPoint içinde çalışır. Kütüphane VBA'yı çalıştırmaz.