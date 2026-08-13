---
title: Управление маркированными и нумерованными списками в презентациях на Java
linktitle: Управление списками
type: docs
weight: 60
url: /ru/java/manage-lists/
keywords:
- маркер
- маркированный список
- нумерованный список
- символьный маркер
- изображение‑маркер
- пользовательский маркер
- многоуровневый список
- создать маркер
- добавить маркер
- добавить список
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать маркированные, изображение‑маркеры, многоуровневые и нумерованные списки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Java."
---
## **Обзор**

Aspose.Slides for Java позволяет создавать и форматировать маркированные и нумерованные списки в презентациях PowerPoint и OpenDocument. Элемент списка — это абзац, настройки маркера которого управляются через формат абзаца.

Используйте метод [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/#getParagraphFormat--) для доступа к настройкам списков уровня абзаца. Основной вход — [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getBullet--), который возвращает объект [IBulletFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/). С помощью этого объекта вы можете установить тип маркера, символ, изображение, цвет, размер, стиль нумерации и начальное число.

В этой статье показано, как:

- создать маркированный список с пользовательским символом
- создать изображение‑маркер
- создать многоуровневый список, задав глубину абзаца
- создать нумерованный список
- просмотреть и изменить форматирование списка в существующей презентации

## **Создать маркированный список**

Чтобы создать маркированный список, добавьте объекты [IParagraph](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraph/) в [ITextFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/itextframe/) и установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-byte-) в значение [BulletType.Symbol](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/#Symbol). Затем можно задать [IBulletFormat.setChar](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#getColor--) и [IBulletFormat.setHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setHeight-float-) для управления внешним видом маркера.

Следующий код на Java демонстрирует, как создать маркированный список на слайде:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Символьные маркеры](symbol_bullets.png)

## **Создать нумерованный список**

Используйте нумерованные списки, когда порядок элементов важен. Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-byte-) в значение [BulletType.Numbered](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/#Numbered). Вы также можете выбрать формат нумерации с помощью [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) или задать [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-), если список должен начинаться с числа, отличного от 1.

Следующий код на Java показывает, как создать нумерованный список на слайде:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Нумерованные маркеры](numbered_bullets.png)

## **Создать изображение‑маркер**

Aspose.Slides позволяет заменить обычный символ маркера изображением. Изображения‑маркеры лучше всего работают с простыми изображениями, которые остаются разборчивыми при небольшом размере, например, иконками или небольшими прозрачными PNG‑файлами.

{{% alert color="info" %}}
В идеале, если вы планируете заменить обычный символ маркера изображением, лучше выбрать простую графику с прозрачным фоном. Такие изображения хорошо подходят в качестве пользовательских символов маркеров.

Имейте в виду, что изображение будет уменьшено до очень небольшого размера. По этой причине мы настоятельно рекомендуем выбирать изображение, которое остаётся чётким и визуально эффективным при использовании в качестве маркера в списке.
{{% /alert %}}

Чтобы создать изображение‑маркер, добавьте изображение в [Presentation.getImages](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getImages--) и присвойте полученный объект изображения [IBulletFormat.getPicture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#getPicture--). Установите [IBulletFormat.setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibulletformat/#setType-byte-) в значение [BulletType.Picture](https://reference.aspose.com/slides/ru/java/com.aspose.slides/bullettype/#Picture) перед назначением изображения.

Допустим, у нас есть файл "image.png":

![Изображение для маркеров](picture_for_bullets.png)

Следующий код на Java показывает, как создать изображение‑маркеры на слайде:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Изображение‑маркеры](picture_bullets.png)

## **Создать многоуровневый список**

Для размещения элементов списка на разных уровнях используйте [IParagraphFormat.setDepth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#setDepth-short-). Уровень 0 — это верхний уровень, уровень 1 — вложенный под ним и так далее.

Следующий код на Java показывает, как создать многоуровневый маркированный список:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Результат:

![Многоуровневый список](multilevel_list.png)

## **Изменить существующий список**

Чтобы изменить форматирование списка в существующей презентации, получите доступ к целевому абзацу и обновите его настройки [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getBullet--). Те же свойства, которые используются для создания списков, могут быть использованы для просмотра или изменения списков, загруженных из файлов PPT, PPTX или ODP.

Следующий код на Java меняет первый абзац в текстовом фрейме, чтобы использовать стиль нумерованного списка:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Можно ли экспортировать маркированные и нумерованные списки в PDF или изображения?

Да. Aspose.Slides сохраняет форматирование списков, если целевой формат поддерживает соответствующее размещение текста и функции маркеров.

### Могу ли я редактировать списки в существующих презентациях?

Да. Загрузите презентацию, получите доступ к целевому абзацу, просмотрите или обновите его настройки [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iparagraphformat/#getBullet--), и сохраните презентацию.

### Может ли список содержать нелатинский текст?

Да. Текст элементов списка может содержать символы Unicode, поэтому вы можете создавать списки в многоязычных презентациях. Убедитесь, что шрифты, используемые в презентации, поддерживают необходимые вам символы.