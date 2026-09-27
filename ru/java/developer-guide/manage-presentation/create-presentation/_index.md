---
title: Создание презентаций на Java
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/java/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PPT
- новый PPT
- создать PPTX
- новый PPTX
- создать ODP
- новый ODP
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Создавайте презентации на Java с помощью Aspose.Slides — генерируйте файлы PPT, PPTX и ODP, используйте поддержку OpenDocument и сохраняйте их программно для надёжных результатов."
---
## **Обзор**

В этой статье показано, как создать презентацию в Aspose.Slides, добавить форму с текстом на её первый слайд и сохранить результат в файл PPTX. Чтобы открыть существующую презентацию и сохранить её в другом формате, см. [Открытие презентаций](/slides/ru/java/open-presentation/) и [Сохранение презентаций](/slides/ru/java/save-presentation/). В конце приведён короткий FAQ с ответами на часто задаваемые вопросы о форматах, шаблонах, размере слайдов, единицах измерения, использовании памяти, потоках, лицензировании, цифровой подписи и поддержке VBA.

Прежде чем начать, добавьте Aspose.Slides for Java в свой проект из Maven‑репозитория Aspose. Смотрите раздел [Установка](/slides/ru/java/installation/) для настройки Maven и требований к Linux.

## **Создание презентации**

Создание файла PowerPoint с нуля в Aspose.Slides for Java начинается с создания экземпляра класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Конструктор возвращает пустую презентацию с одним слайдом, готовым для форм, текста, диаграмм или любого другого контента, необходимого вашему приложению. После изменения этого слайда или добавления новых вы можете сохранить результат в форматы PPTX, устаревший PPT или OpenDocument.

Чтобы создать презентацию и поместить форму с текстом на её первый слайд, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). В новой презентации уже есть один пустой слайд.  
2. Получите этот слайд по индексу 0 из коллекции, которую возвращает метод [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--).  
3. Добавьте [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) типа `Cloud` с помощью метода [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), и задайте его текст с помощью [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Сохраните презентацию как файл PPTX с помощью метода [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Ниже приведён полный пример программы. В Maven‑проекте из раздела [Установка](/slides/ru/java/installation/) сохраните его как *src/main/java/HelloSlides.java* и запустите `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Создайте презентацию. Она уже содержит один пустой слайд.
        Presentation presentation = new Presentation();
        try {
            // Получите первый слайд.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Добавьте форму облака и поместите в неё текст.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Сохраните презентацию как файл PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Левый верхний угол облака находится на расстоянии 20 пунктов от левого края и 20 пунктов от верхнего края слайда, а сама форма имеет ширину 200 пунктов и высоту 80 пунктов. Программа сохраняет *new_presentation.pptx* с одним слайдом, содержащим облако и его текст. Без лицензии Aspose.Slides также добавляет водяной знак оценки на каждый сохраняемый слайд; см. раздел [Лицензирование](/slides/ru/java/licensing/).

Результат:

![Новая презентация](new_presentation.png)

## **FAQ**

### В какие форматы можно сохранить новую презентацию?

Можно сохранять в [PPTX, PPT и ODP](/slides/ru/java/save-presentation/), а также экспортировать в [PDF](/slides/ru/java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/java/convert-powerpoint-to-xps/), [HTML](/slides/ru/java/convert-powerpoint-to-html/), [SVG](/slides/ru/java/render-a-slide-as-an-svg-image/) и [изображения](/slides/ru/java/convert-powerpoint-to-png/), среди прочих.

### Можно ли начать с шаблона (POTX/POTM) и сохранить как обычный PPTX?

Да. Загрузите шаблон и сохраните в нужный формат; форматы POTX/POTM/PPTM и аналогичные [поддерживаются](/slides/ru/java/supported-file-formats/).

### Как контролировать размер/соотношение сторон слайда при создании презентации?

Установите [размер слайда](/slides/ru/java/slide-size/) (в том числе предустановки 4:3 и 16:9 или пользовательские размеры) и выберите способ масштабирования содержимого.

### В каких единицах измеряются размеры и координаты?

В пунктах: 1 дюйм = 72 пункта.

### Как работать с очень большими презентациями (с множеством медиа‑файлов), чтобы снизить использование памяти?

Используйте [стратегии управления BLOB](/slides/ru/java/manage-blob/), ограничивайте хранение в памяти, используя временные файлы, и отдавайте предпочтение файловым рабочим процессам вместо чисто потоковых операций в памяти.

### Можно ли создавать/сохранять презентации параллельно?

Нельзя работать с одним экземпляром [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) из [нескольких потоков](/slides/ru/java/multithreading/). Запускайте отдельные, изолированные экземпляры для каждого потока или процесса.

### Как удалить пробный водяной знак и ограничения?

[Примените лицензию](/slides/ru/java/licensing/) один раз за процесс. XML‑файл лицензии должен оставаться без изменений, а процесс установки лицензии следует синхронизировать при работе нескольких потоков.

### Можно ли добавить цифровую подпись к создаваемому PPTX?

Да. [Цифровые подписи](/slides/ru/java/digital-signature-in-powerpoint/) (добавление и проверка) поддерживаются для презентаций.

### Поддерживаются ли макросы (VBA) в созданных презентациях?

Да. Вы можете [создавать/редактировать проекты VBA](/slides/ru/java/presentation-via-vba/) и сохранять файлы с поддержкой макросов, такие как PPTM/PPSM.