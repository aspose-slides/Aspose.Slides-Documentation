---
title: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/cpp/default-font/
---

## **Установить шрифт по умолчанию**
Используя Aspose.Slides для C++, вы можете установить шрифт по умолчанию в презентациях PowerPoint. В класс **SaveOptions** был добавлен новый метод [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492). Он позволяет установить шрифт по умолчанию, который используется вместо всех отсутствующих шрифтов при сохранении презентаций в различные форматы без перезагрузки презентаций.

Ниже приведен фрагмент кода, демонстрирующий сохранение презентации в [HTML](https://docs.fileformat.com/web/html/) и [PDF](https://docs.fileformat.com/pdf/) с различным шрифтом по умолчанию.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **Используйте шрифты по умолчанию для рендеринга презентации**
Aspose.Slides позволяет вам установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. Эта статья показывает, как определить шрифты DefaultRegular Font и DefaultAsian Font для использования в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги для загрузки шрифтов из внешних каталогов с использованием API Aspose.Slides для C++:

1. Создайте экземпляр LoadOptions.
2. Установите DefaultRegularFont на желаемый шрифт. В следующем примере я использовал Wingdings.
3. Установите DefaultAsianFont на желаемый шрифт. Я также использовал Wingdings в следующем примере.
4. Загрузите презентацию, используя Presentation и установив параметры загрузки.
5. Теперь сгенерируйте миниатюру слайда, PDF и XPS для проверки результатов.

Реализация вышеуказанного представлена ниже.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DefaultFonts-DefaultFonts.cpp" >}}