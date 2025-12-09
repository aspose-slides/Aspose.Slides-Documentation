---
title: Переход слайда
type: docs
weight: 80
url: /ru/nodejs-java/slide-transition/
keywords: "Переход слайда PowerPoint, morph‑переход в JavaScript"
description: "Переход слайда PowerPoint, morph‑переход PowerPoint в JavaScript"
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java также позволяет разработчикам управлять или настраивать эффекты переходов слайдов. В этой статье мы обсудим, как легко контролировать переходы слайдов с помощью Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Чтобы было проще понять, мы продемонстрировали использование Aspose.Slides for Node.js via Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов к слайдам, но и настраивать поведение этих эффектов переходов.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
2. Примените тип перехода слайда к слайду, выбрав один из переходных эффектов, предлагаемых Aspose.Slides for Node.js via Java, через перечисление TransitionType.
3. Запишите изменённый файл презентации.
```javascript
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Применить переход типа circle к слайду 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Применить переход типа comb к слайду 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Сохранить презентацию на диск
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Добавить продвинутый переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы улучшить и более точно контролировать этот простой переход, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
2. Примените тип перехода слайда к слайду, выбрав один из переходных эффектов, предлагаемых Aspose.Slides for Node.js via Java.
3. Вы также можете установить переход на «Продвижение по щелчку», после определённого периода времени или оба варианта.
4. Если переход слайда включён с опцией «Продвижение по щелчку», переход будет осуществлён только при щелчке мышью. Кроме того, если установлено свойство «Advance After Time», переход произойдёт автоматически после истечения заданного времени.
5. Запишите изменённую презентацию в файл презентации.
```javascript
// Создать экземпляр класса Presentation, представляющего файл презентации
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Применить переход типа circle к слайду 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Установить время перехода 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Применить переход типа comb к слайду 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Установить время перехода 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Применить переход типа zoom к слайду 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Установить время перехода 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Сохранить презентацию на диск
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Переход Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition). Это новый morph‑переход, представленный в PowerPoint 2019.

{{% /alert %}} 

Переход Morph позволяет анимировать плавное перемещение от одного слайда к другому. В этой статье описывается концепция и способы использования Morph‑перехода. Чтобы эффективно использовать Morph‑переход, вам потребуются два слайда с хотя бы одним общим объектом. Самый простой способ — продублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить переход [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) для второго слайда.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Типы Morph‑переходов**
Добавлено новое перечисление [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType). Оно представляет разные типы Morph‑переходов слайдов.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Morph‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: Morph‑переход будет выполнен с переносом текста по словам, где это возможно.
- ByChar: Morph‑переход будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить morph‑переход для слайда и изменить тип morph:
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Установить эффекты перехода**
Aspose.Slides for Node.js via Java поддерживает установку эффектов перехода, таких как «из чёрного», «слева», «справа» и т.д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Получите ссылку на слайд.
- Установите эффект перехода.
- Сохраните презентацию как файл [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

В примере ниже мы задали эффекты перехода.
```javascript
// Создать экземпляр класса Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Установить эффект
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Сохранить презентацию на диск
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Можно ли контролировать скорость воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) перехода, используя настройку [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить аудио к переходу и зациклить его?**

Да. Вы можете встроить звук для перехода и управлять поведением через настройки, такие как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), плюс метаданные такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) и [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте нужный тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам обеспечивает одинаковый результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Проверьте [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/); это значение точно указывает, какой эффект применяется.