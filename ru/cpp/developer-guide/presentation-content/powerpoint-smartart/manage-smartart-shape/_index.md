---
title: Управление формой SmartArt
type: docs
weight: 20
url: /ru/cpp/manage-smartart-shape/
---


## **Создание формы SmartArt**
Aspose.Slides для C++ теперь позволяет добавлять пользовательские формы SmartArt на слайды с нуля. Aspose.Slides для C++ предоставляет самый простой API для создания форм SmartArt самым простым способом. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте форму SmartArt, установив тип компоновки (LayoutType).
- Запишите изменённую презентацию в файл PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Получение доступа к форме SmartArt на слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным в слайд презентации. В примере кода мы пройдёмся по каждой форме внутри слайда и проверим, является ли она формой SmartArt. Если форма является типом SmartArt, мы приведем её к экземпляру SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Получение доступа к форме SmartArt с определённым типом компоновки**
Следующий образец кода поможет получить доступ к форме SmartArt с определённым типом компоновки. Обратите внимание, что вы не можете изменить тип компоновки формы SmartArt, так как он только для чтения и устанавливается только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Проверьте форму SmartArt с определённым типом компоновки и выполните все необходимые действия.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Изменение стиля формы SmartArt**
Следующий образец кода поможет получить доступ к форме SmartArt с определённым типом компоновки.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Найдите форму SmartArt с определённым стилем.
- Установите новый стиль для формы SmartArt.
- Сохраните презентацию.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Изменение цветового стиля формы SmartArt**
В этом примере мы узнаем, как изменить цветовой стиль для любой формы SmartArt. В следующем образце кода мы получим доступ к форме SmartArt с определённым цветовым стилем и изменим его стиль.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по каждой форме внутри первого слайда.
- Проверьте, является ли форма типом SmartArt и приведите выбранную форму к SmartArt, если это SmartArt.
- Найдите форму SmartArt с определённым цветовым стилем.
- Установите новый цветовой стиль для формы SmartArt.
- Сохраните презентацию.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}