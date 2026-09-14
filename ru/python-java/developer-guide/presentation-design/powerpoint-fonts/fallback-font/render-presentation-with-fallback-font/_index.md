---
title: Отрисовка презентаций с резервными шрифтами в Python через Java
linktitle: Отрисовка презентаций
type: docs
weight: 30
url: /ru/python-java/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- рендер PowerPoint
- рендер презентации
- рендер слайда
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Отрисовывайте презентации с резервными шрифтами в Aspose.Slides для Python через Java — сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на Python."
---
## **Обзор**

Aspose.Slides позволяет рендерить презентации с использованием правил резервных шрифтов. Эта статья показывает, как создать коллекцию правил резервных шрифтов, изменить её правила, удалив или добавив резервные шрифты, и назначить коллекцию с помощью метода [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

После назначения коллекции правил резервных шрифтов объекту [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/) презентации, правила применяются во время операций, таких как сохранение, рендеринг и конвертация презентации. В примере показано, как использовать настроенные правила при рендеринге миниатюры слайда и сохранении её как изображения JPEG.

## **Отрисовка слайда с использованием правил резервных шрифтов**

Следующий пример включает следующие шаги:

1. [Создать коллекцию правил резервных шрифтов](/slides/ru/python-java/create-fallback-fonts-collection/).
1. [Удалить] резервный шрифт из правила и [добавить резервные шрифты] в другое правило.
1. Назначьте коллекцию правил, используя [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) на менеджере шрифтов, полученном через [getFontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getFontsManager).
1. Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) для сохранения презентации в том же формате или в другом формате. После назначения коллекции правил резервных шрифтов объекту [FontsManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontsmanager/), эти правила применяются при операциях над презентацией: сохранении, рендеринге, конвертации и т.д.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Создать новую коллекцию правил.
fallback_rules = FontFallBackRulesCollection()

# Создать несколько правил.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Попробовать удалить резервный шрифт "Tahoma" из правил.
    fallback_rule.remove("Tahoma")

    # Обновить правила для заданного диапазона.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Удалить существующее правило, оставив как минимум одно правило для рендеринга.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Назначить подготовленную коллекцию правил.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Отрисовать миниатюру, используя настроенную коллекцию правил.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Сохранить изображение на диск в формате JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Узнайте больше о том, как [конвертировать PPT и PPTX в JPG в Python через Java](/slides/ru/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}