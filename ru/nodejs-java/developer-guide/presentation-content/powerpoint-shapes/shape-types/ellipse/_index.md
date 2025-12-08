---
title: Эллипс
type: docs
weight: 30
url: /ru/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

В этой теме мы расскажем разработчикам, как добавлять эллиптические фигуры на слайды с помощью Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java предоставляет упрощённый набор API для рисования различных фигур всего в несколько строк кода.

{{% /alert %}} 

## **Создание эллипса**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили эллипс на первый слайд
```javascript
// Создайте объект класса Presentation, представляющий PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получите первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавьте AutoShape типа ellipse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Запишите файл PPTX на диск
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создание отформатированного эллипса**
Чтобы добавить более оформленный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) объекта [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Установите тип заливки эллипса как Solid.
- Установите цвет заливки эллипса через свойство SolidFillColor.Color объекта [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat), связанного с объектом [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape).
- Установите цвет линий эллипса.
- Установите ширину линий эллипса.
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили отформатированный эллипс на первый слайд презентации.
```javascript
// Создайте объект класса Presentation, представляющий PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получите первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Добавьте AutoShape типа эллипса
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Примените форматирование к фигуре эллипса
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Примените форматирование к линии эллипса
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Запишите файл PPTX на диск
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Для предсказуемых результатов основывайте расчёты на размере слайда и преобразовывайте необходимые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Измените порядок рисования объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или открывать объекты, находящиеся под ним.

**Как анимировать появление или выделение эллипса?**

[Apply](/slides/ru/nodejs-java/shape-animation/) входные, акцентирующие или выходные эффекты к фигуре, а также настройте триггеры и тайминг, чтобы управлять тем, когда и как воспроизводится анимация.