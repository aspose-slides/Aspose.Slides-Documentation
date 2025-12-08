---
title: ActiveX
type: docs
weight: 80
url: /ru/nodejs-java/activex/
---

{{% alert color="primary" %}} 

ActiveX‑контролы используются в презентациях. Aspose.Slides for Node.js via Java позволяет добавлять и управлять ActiveX‑контролами, но они несколько сложнее в управлении по сравнению с обычными объектами презентации. Мы реализовали поддержку добавления ActiveX‑контроля Media Player в Aspose.Slides. Обратите внимание, что ActiveX‑контролы не являются фигурами; они не являются частью [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/). Они находятся в отдельном [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) . В этой статье мы покажем, как работать с ними.

{{% /alert %}} 

## **Добавление ActiveX‑контроля Media Player на слайд**
Чтобы добавить ActiveX‑контрол Media Player, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и получите пустой объект презентации.  
2. Получите целевой слайд из [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
3. Добавьте ActiveX‑контрол Media Player, вызвав метод [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) из [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/).  
4. Доступитесь к добавленному контролу Media Player и задайте путь к видео, используя его свойства.  
5. Сохраните презентацию в файл PPTX.  

Этот пример кода, построенный по описанным шагам, демонстрирует, как добавить ActiveX‑контрол Media Player на слайд:
```javascript
// Создать пустой экземпляр презентации
var pres = new aspose.slides.Presentation();
try {
    // Добавление ActiveX‑контроля Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Доступ к контролю Media Player ActiveX и установка пути к видео
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Сохранить презентацию
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Модификация ActiveX‑контроля**

Чтобы управлять простыми ActiveX‑контролями, такими как текстовое поле и простая кнопка команд на слайде, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию, содержащую ActiveX‑контролы.  
2. Получите ссылку на слайд по его индексу.  
3. Получите доступ к ActiveX‑контролям на слайде, обратившись к [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/).  
4. Доступитесь к контролу TextBox1 через объект [Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/).  
5. Измените свойства контролa TextBox1, включая текст, шрифт, высоту шрифта и положение рамки.  
6. Получите второй контрол под названием CommandButton1.  
7. Измените подпись кнопки, шрифт и позицию.  
8. Сдвиньте положение рамок всех ActiveX‑контролей.  
9. Запишите изменённую презентацию в файл PPTX.  

Этот пример кода, построенный по описанным шагам, показывает, как управлять простым ActiveX‑контролем:
```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Доступ к презентации с ActiveX‑контролями
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Доступ к первому слайду в презентации
    var slide = pres.getSlides().get_Item(0);
    // изменение текста TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Изменение заменяющего изображения. PowerPoint заменит это изображение при активации ActiveX,
        // поэтому иногда можно оставить изображение без изменений.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Изменение подписи кнопки
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Изменение заменяющего
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // сдвиг вниз на 100 пунктов
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // удаление контролов
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Сохраняет ли Aspose.Slides ActiveX‑контролы при чтении и повторном сохранении, если они не могут быть выполнены в среде Python?**

Да. Aspose.Slides рассматривает их как часть презентации и может читать/изменять их свойства и позицию; выполнение самих контролов не требуется для их сохранения.

**Чем ActiveX‑контролы отличаются от OLE‑объектов в презентации?**

ActiveX‑контролы — это интерактивные управляемые элементы (кнопки, текстовые поля, медиаплеер), тогда как [OLE](/slides/ru/nodejs-java/manage-ole/) относится к внедрённым объектам приложений (например, лист Excel). Они хранятся и обрабатываются по‑разному и имеют различную модель свойств.

**Работают ли события ActiveX и макросы VBA, если файл был изменён Aspose.Slides?**

Aspose.Slides сохраняет существующую разметку и метаданные; однако события и макросы запускаются только в PowerPoint на Windows при разрешенной безопасности. Библиотека не выполняет VBA.