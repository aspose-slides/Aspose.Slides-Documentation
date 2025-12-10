---
title: Группировка форм в презентациях на C++
linktitle: Группа форм
type: docs
weight: 40
url: /ru/cpp/group/
keywords:
- групповая форма
- группа форм
- добавить группу
- альтернативный текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как группировать и разъединять формы в презентациях PowerPoint с помощью Aspose.Slides для C++ — быстрый пошаговый гид с бесплатным кодом на C++."
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта возможность помогает разработчикам создавать более насыщенные презентации. Aspose.Slides for C++ поддерживает добавление и доступ к групповым формам. Можно добавить формы в уже созданную групповую форму, заполнив её, или получить доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с помощью Aspose.Slides for C++:

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получить ссылку на слайд, используя его индекс.
1. Добавить групповую форму на слайд.
1. Добавить формы в созданную групповую форму.
1. Сохранить изменённую презентацию в файл PPTX.

Ниже приведён пример, добавляющий групповую форму на слайд.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Доступ к свойству AltText**
В этом разделе показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить AltText групповой формы на слайде с помощью Aspose.Slides for C++:

1. Создать экземпляр класса `Presentation`, представляющий файл PPTX.
1. Получить ссылку на слайд, используя его индекс.
1. Получить доступ к коллекции форм слайдов.
1. Получить доступ к групповой форме.
1. Получить доступ к свойству AltText.

Ниже приведён пример, получающий альтернативный текст групповой формы.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Поддерживается ли вложенное группирование (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) имеет метод [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/), который напрямую указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как контролировать порядок Z‑уровня группы относительно других объектов на слайде?**

Используйте свойство Z‑Order позиции группы в классе [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) через метод [get_zorderposition](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) для проверки её положения в стекe отображения.

**Можно ли запретить перемещение/изменение/разгруппировку?**

Да. Раздел блокаировки группы доступен через [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/), что позволяет ограничить операции с объектом.