---
title: Управляйте графикой SmartArt в презентациях с помощью C++
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/cpp/manage-smartart-shape/
keywords:
- объект SmartArt
- графика SmartArt
- стиль SmartArt
- цвет SmartArt
- создание SmartArt
- добавление SmartArt
- редактирование SmartArt
- изменение SmartArt
- доступ к SmartArt
- тип макета SmartArt
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint на C++ с помощью Aspose.Slides, предоставляя лаконичные примеры кода и рекомендации, ориентированные на производительность."
---

## **Создать объект SmartArt**
Aspose.Slides for C++ теперь позволяет добавлять пользовательские объекты SmartArt в их слайды с нуля. Aspose.Slides for C++ предоставляет самый простой API для создания объектов SmartArt самым простым способом. Чтобы создать объект SmartArt на слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте объект SmartArt, задав его LayoutType.
- Сохраните изменённую презентацию в виде файла PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Доступ к объекту SmartArt на слайде**
В следующем коде будет использоваться доступ к объектам SmartArt, добавленным в слайд презентации. В примере кода мы пройдемся по каждому объекту внутри слайда и проверим, является ли он объектом SmartArt. Если объект имеет тип SmartArt, мы приведём его к экземпляру SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Доступ к объекту SmartArt с определённым Layout Type**
В следующем примере кода будет показан доступ к объекту SmartArt с определённым LayoutType. Обратите внимание, что изменить LayoutType у SmartArt нельзя, так как он только для чтения и задаётся только при добавлении объекта SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с объектом SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по каждому объекту внутри первого слайда.
- Проверьте, является ли объект типом SmartArt, и при необходимости приведите выбранный объект к SmartArt.
- Проверьте объект SmartArt с определённым LayoutType и выполните необходимые дальнейшие действия.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Изменить стиль объекта SmartArt**
В следующем примере кода будет показан доступ к объекту SmartArt с определённым LayoutType.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с объектом SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по каждому объекту внутри первого слайда.
- Проверьте, является ли объект типом SmartArt, и при необходимости приведите выбранный объект к SmartArt.
- Найдите объект SmartArt с определённым Style.
- Установите новый Style для объекта SmartArt.
- Сохраните презентацию.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Изменить цветовой стиль объекта SmartArt**
В этом примере мы научимся менять цветовой стиль любого объекта SmartArt. В следующем примере кода будет выполнен доступ к объекту SmartArt с определённым цветовым стилем и его изменение.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с объектом SmartArt.
- Получите ссылку на первый слайд, используя его Index.
- Пройдитесь по каждому объекту внутри первого слайда.
- Проверьте, является ли объект типом SmartArt, и при необходимости приведите выбранный объект к SmartArt.
- Найдите объект SmartArt с определённым Color Style.
- Установите новый Color Style для объекта SmartArt.
- Сохраните презентацию.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Могу ли я анимировать SmartArt как единый объект?**

Да. SmartArt является объектом, поэтому вы можете применять [standard animations](/slides/ru/cpp/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения) так же, как и к другим объектам.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний ID?**

Задайте и используйте Alternative Text (AltText) и ищите объект по этому значению — это рекомендуемый способ найти нужный объект.

**Могу ли я группировать SmartArt с другими объектами?**

Да. Вы можете группировать SmartArt с другими объектами (изображения, таблицы и т.д.) и затем [manipulate the group](/slides/ru/cpp/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение объекта; библиотека может [render individual shapes](/slides/ru/cpp/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок обеспечивает высокую точность для [PDF export](/slides/ru/cpp/convert-powerpoint-to-pdf/), предоставляя разнообразные параметры качества и совместимости.