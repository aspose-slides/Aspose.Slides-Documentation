---
title: Python ile Sunumlarda ActiveX Kontrollerini Yönetin
linktitle: ActiveX
type: docs
weight: 80
url: /tr/python-net/activex/
keywords:
- ActiveX
- ActiveX denetimi
- ActiveX yönetimi
- ActiveX ekleme
- ActiveX değiştirme
- medya oynatıcı
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in ActiveX'i nasıl kullandığını, PowerPoint sunumlarını otomatikleştirip iyileştirdiğini öğrenin; geliştiricilere slaytlar üzerinde güçlü kontrol sağlar."
---
## **Giriş**

ActiveX denetimleri sunumlarda kullanılır. Aspose.Slides for Python via .NET, ActiveX denetimlerini yönetmenizi sağlar, ancak bunları yönetmek biraz daha zordur ve normal sunum şekillerinden farklıdır. Aspose.Slides for Python via .NET 6.9.0 sürümünden itibaren, bileşen ActiveX denetimlerini yönetmeyi destekler. Şu anda, sunumunuzda önceden eklenmiş bir ActiveX denetimine erişebilir ve çeşitli özelliklerini kullanarak değiştirebilir veya silebilirsiniz. Unutmayın, ActiveX denetimleri şekil değildir ve sunumun IShapeCollection koleksiyonunun bir parçası değil, ayrı IControlCollection içinde bulunur. Bu makale, onlarla nasıl çalışılacağını gösterir.
## **ActiveX Kontrollerini Değiştir**
Bir slaytta metin kutusu ve basit komut düğmesi gibi basit bir ActiveX denetimini yönetmek için:

1. Presentation sınıfının bir örneğini oluşturun ve içinde ActiveX denetimleri bulunan sunumu yükleyin.
1. İndeksi ile bir slayt referansı alın.
1. IControlCollection'ı kullanarak slayttaki ActiveX denetimlerine erişin.
1. ControlEx nesnesini kullanarak TextBox1 ActiveX denetimine erişin.
1. TextBox1 ActiveX denetiminin metin, yazı tipi, yazı tipi yüksekliği ve çerçeve konumu gibi çeşitli özelliklerini değiştirin.
1. CommandButton1 adlı ikinci erişim denetimine erişin.
1. Düğmenin başlığını, yazı tipini ve konumunu değiştirin.
1. ActiveX denetimlerinin çerçeve konumunu kaydırın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod parçacığı, sunum slaytlarındaki ActiveX denetimlerini aşağıda gösterildiği gibi günceller.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# ActiveX denetimlerine sahip sunuma erişim
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Sunumdaki ilk slayta erişim
    slide = presentation.slides[0]

    # TextBox metnini değiştiriyor
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # yerine koyma resmini değiştiriyor. PowerPoint, ActiveX etkinleştirilirken bu resmi değiştirecektir, bu yüzden bazen resmi değiştirmeden bırakmak sorun değil.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # Düğme başlığını değiştiriyor
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # yerine koymayı değiştiriyor
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # ActiveX çerçevelerini 100 puan aşağı kaydırma
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Düzenlenmiş ActiveX denetimleriyle sunumu kaydet
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Şimdi denetimler kaldırılıyor
    slide.controls.clear()

    # Temizlenmiş ActiveX denetimleriyle sunumu kaydetme
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **ActiveX Media Player Kontrolü Ekle**
ActiveX Media Player kontrolü eklemek için aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun ve içinde Media Player ActiveX denetimleri bulunan örnek sunumu yükleyin.
1. Hedef Presentation sınıfının bir örneğini oluşturun ve boş bir sunum örneği oluşturun.
1. Şablon sunumundaki Media Player ActiveX denetimli slaytı hedef Presentation'a kopyalayın.
1. Hedef Presentation'daki kopyalanmış slayta erişin.
1. IControlCollection'ı kullanarak slayttaki ActiveX denetimlerine erişin.
1. Media Player ActiveX denetimine erişin ve özelliklerini kullanarak video yolunu ayarlayın.
1. Sunumu bir PPTX dosyasına kaydedin.

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
with slides.Presentation(path + "template.pptx") as presentation:

    # Boş bir sunum örneği oluşturun
    with slides.Presentation() as newPresentation:

        # Varsayılan slaytı kaldırın
        newPresentation.slides.remove_at(0)

        # Media Player ActiveX denetimi bulunan slaytı kopyalayın
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Media Player ActiveX denetimine erişin ve video yolunu ayarlayın
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Sunumu kaydedin
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides, Python çalışma zamanında yürütülemiyorsa ActiveX denetimlerini okurken ve yeniden kaydederken korur mu?**

Evet. Aspose.Slides, bunları sunumun bir parçası olarak kabul eder ve özelliklerini ve çerçevelerini okuyabilir/değiştirebilir; denetimlerin kendisinin yürütülmesi, bunların korunması için gerekli değildir.

**ActiveX denetimleri bir sunumdaki OLE nesnelerinden nasıl farklıdır?**

ActiveX denetimleri, etkileşimli yönetilen denetimlerdir (düğmeler, metin kutuları, medya oynatıcı), oysa [OLE](/slides/tr/python-net/manage-ole/) gömülü uygulama nesnelerini (örneğin bir Excel çalışma sayfası) ifade eder. Bunlar farklı şekilde depolanır ve işlenir ve farklı özellik modellerine sahiptir.

**Aspose.Slides tarafından dosya değiştirildiyse ActiveX olayları ve VBA makroları çalışır mı?**

Aspose.Slides mevcut işaretlemeyi ve meta verileri korur; ancak, olaylar ve makrolar yalnızca güvenlik izin verdiğinde Windows'ta PowerPoint içinde çalışır. Kütüphane VBA’yı çalıştırmaz.