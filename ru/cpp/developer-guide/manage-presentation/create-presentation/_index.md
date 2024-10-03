---
title: Создание презентации - C++ PowerPoint API
linktitle: Создание презентации
type: docs
weight: 10
url: /ru/cpp/create-presentation/
description: Чтобы создать презентацию PowerPoint с использованием C++ API, пожалуйста, следуйте шагам, указанным в этой статье. Код добавляет линию на первый слайд презентации.
---

## **Создание презентации PowerPoint**
Чтобы добавить простую линию на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте АвтоФигуру типа Линия с помощью метода AddAutoShape, предоставленного объектом Shapes.
1. Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}