---
title: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/cpp/presentation-viewer/
keywords: "Просмотрщик PowerPoint PPT"
description: "Просмотрщик PowerPoint PPT на C++"
---

## **Генерация SVG изображения из слайда**
Aspose.Slides для C++ используется для создания файлов презентаций, содержащих слайды. Эти слайды можно просмотреть, открыв презентации с помощью Microsoft PowerPoint. Но иногда разработчикам может потребоваться просмотреть слайды в виде изображений SVG в любимом просмотрщике изображений. В таких случаях Aspose.Slides для C++ позволяет экспортировать отдельный слайд в изображение SVG. Эта статья описывает, как использовать эту функцию. Чтобы сгенерировать изображение SVG из любого желаемого слайда с помощью Aspose.Slides.Pptx для C++, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на желаемый слайд, используя его ID или индекс.
- Получите изображение SVG в потоке памяти.
- Сохраните поток памяти в файл.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSlidesSVGImage-CreateSlidesSVGImage.cpp" >}}
## **Генерация SVG с пользовательскими идентификаторами форм**
Теперь Aspose.Slides для C++ можно использовать для генерации SVG из слайда с пользовательскими идентификаторами форм. Эти слайды можно просмотреть, открыв презентации с помощью Microsoft PowerPoint. Но иногда разработчикам может потребоваться просмотреть слайды в виде изображений SVG в любимом просмотрщике изображений. В таких случаях Aspose.Slides для C++ позволяет экспортировать отдельный слайд в изображение SVG. Для этой цели свойство ID было добавлено в ISvgShape для поддержки пользовательских идентификаторов форм в сгенерированном SVG. Для реализации этой функции был представлен CustomSvgShapeFormattingController, который вы можете использовать для установки идентификатора формы.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GeneratingSVGWithCustomShapeIDS-GeneratingSVGWithCustomShapeIDS.cpp" >}}

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomSvgShapeFormattingController-CustomSvgShapeFormattingController.cpp" >}}


## **Создание миниатюры слайда**
Aspose.Slides для C++ используется для создания файлов презентаций, содержащих слайды. Эти слайды можно просмотреть, открыв файлы презентаций с помощью Microsoft PowerPoint. Но иногда разработчикам может потребоваться просмотреть слайды в виде изображений с помощью любимого просмотрщика изображений. В таких случаях Aspose.Slides для C++ помогает вам сгенерировать миниатюры слайдов. Чтобы сгенерировать миниатюру любого желаемого слайда с помощью Aspose.Slides для C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда на заданном масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RenderSlides-ThumbnailFromSlide.cpp" >}}

## **Создание миниатюры с пользовательскими размерностями**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда на заданном масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailWithUserDefinedDimensions-ThumbnailWithUserDefinedDimensions.cpp" >}}

## **Создание миниатюры из слайда в режиме заметок**
Чтобы сгенерировать миниатюру любого желаемого слайда в режиме заметок с помощью Aspose.Slides для C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда на заданном масштабе в режиме заметок.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

Ниже приведен фрагмент кода, который создает миниатюру первого слайда презентации в режиме заметок.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ThumbnailFromSlideInNotes-ThumbnailFromSlideInNotes.cpp" >}}