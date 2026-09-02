---
title: "Клонирование слайдов презентации на Android"
linktitle: "Клонировать слайды"
type: docs
weight: 35
url: /ru/androidjava/clone-slides/
keywords:
- "клонирование слайда"
- "копировать слайд"
- "сохранить слайд"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Дублируйте слайды PowerPoint с помощью Aspose.Slides для Android. Следуйте нашим понятным примерам кода на Java, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---
## **Введение**

Клонирование — процесс создания точной копии или реплики чего‑либо. Aspose.Slides для Android через Java также позволяет создавать копию или клон любого слайда и затем вставлять этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не затрагивая оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонировать в конец текущей презентации.
- Клонировать в другую позицию внутри презентации.
- Клонировать в конец другой презентации.
- Клонировать в другую позицию в другой презентации.
- Клонировать в определённую позицию в другой презентации.

В Aspose.Slides для Android через Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlide), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation)) доступны методы [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения перечисленных видов клонирования слайда.

## **Клонирование слайда в конец презентации**
Если требуется клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно приведённым ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) через ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд, который нужно клонировать.
1. Запишите изменённый файл презентации.

В примере ниже мы клонировали слайд (находящийся на первой позиции – индекс 0 – презентации) в конец презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонировать выбранный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование слайда в другую позицию внутри презентации**
Если требуется клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Получите объект, ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) у объекта [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд, который следует клонировать, вместе с индексом новой позиции.
1. Запишите изменённую презентацию в формате PPTX.

В примере ниже мы клонировали слайд (находящийся на индексе 1 – позиция 2 – презентации) в индекс 2 – позиция 3 – презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Получить коллекцию слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    // Клонировать выбранный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, поместив в конец существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection) через ссылку на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) у целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование слайда в другую позицию в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) через ссылку на коллекцию Slides у целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации вместе с желаемой позицией.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из индекса 0 исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонировать выбранный слайд из исходной презентации в указанный индекс в целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование слайда в определённую позицию в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой, сначала следует клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем использовать этот мастер‑слайд при клонировании самого слайда. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.
1. Получите доступ к слайду, который необходимо клонировать, вместе с его мастер‑слайдом.
1. Получите объект [IMasterSlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IMasterSlideCollection) через ссылку на коллекцию Masters у объекта [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [IMasterSlideCollection] и передайте в него мастер‑слайд из исходного PPTX для клонирования.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getSlides--) через ссылку на коллекцию Slides у объекта [Presentation] целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection] и передайте в него слайд из исходной презентации и мастер‑слайд в качестве параметров.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастером (из индекса 0 исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создать экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Создать ISlide из коллекции слайдов в исходной презентации вместе с
        // мастер‑слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонировать выбранный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Клонировать выбранный слайд из исходной презентации с нужным мастером в конец
        // коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Сохранить целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование слайда в конец указанного раздела**
Если нужно клонировать слайд и затем использовать его в той же презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) интерфейса [**ISlideCollection**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides для Android через Java позволяет клонировать слайд из первого раздела и затем вставлять этот клон во второй раздел той же презентации.

Ниже показан фрагмент кода, демонстрирующий, как клонировать слайд и вставить его в указанный раздел.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Сохранить целевую презентацию на диск
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Убедитесь, что размеры слайдов совпадают**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайда, как у исходной. Если размеры различаются, Aspose.Slides не масштабирует автоматически клонированные фигуры – их исходные координаты и размеры сохраняются, что может привести к тому, что содержимое будет смещено или выйдет за пределы слайда.

Перед клонированием мастера и слайда задайте размер слайдов целевой презентации, соответствующий размеру исходной:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Сделайте это перед клонированием мастера и слайда.

## **FAQ**

**Копируются ли заметки докладчика и комментарии рецензентов?**

Да. Страница заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/androidjava/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/androidjava/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в определённый индекс слайда и разместить его в выбранном [разделе](/slides/ru/androidjava/slide-section/). Если целевого раздела нет, сначала создайте его, а затем переместите слайд.