---
title: Извлечение изображений из фигур презентации
linktitle: Изображение из фигуры
type: docs
weight: 100
url: /ru/php-java/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- фон слайда
- фон фигуры
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java — быстрое, удобное для кода решение."
---

## **Извлечение изображений из фигур**

{{% alert color="primary" %}} 

Изображения часто добавляются к фигурам и также часто используются в качестве фонов слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/), который представляет собой коллекцию объектов [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).

В этой статье объясняется, как извлечь изображения, добавленные в презентацию. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, необходимо сначала найти изображение, проходя каждый слайд и затем каждую фигуру. После того как изображение найдено или идентифицировано, его можно извлечь и сохранить как новый файл. 
```php

```


## **FAQ**

**Можно ли извлечь оригинальное изображение без обрезки, эффектов или преобразований фигуры?**

Da. Kogda vy poluchaete izobrajenie figury, vy poluchaete ob'ekt izobrajenija iz [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) prezentacii, chto oznachaet original'nye piksely bez obrrezki ili stilisticheskikh effektov. Rabochij protsess prohodit cherez kollekciiu izobrajenij prezentacii i ob'ekty [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), kotorye khranyat neobrabotannye dannye.

**Suschestvuet li risk duplikatov identichnyh faylov pri massovom sohraneni eh izobrajenij?**

Da, esli sohranyat' vse bez razlichij. [image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) prezentacii mozet soderzhat' odinakovyh binarnyh dannyh, na kotoryh ssylautsya raznye figury ili slajdy. Chtoby izbezhat' duplikatov, sravnivaite heshi, razmery ili soderzhimoe izvlechennykh dannyh pered zapisyu.

**Kak opredelit', kakyie figury sviazany s konkretnym izobrazheniem iz kollektsii prezentacii?**

Aspose.Slides ne khranit obratnye ssylki ot [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) k figuram. Sozdayte soglasovanie v rukakh vo vremya obhoda: kazhdyj raz, kogda vy nahodite ssylku na [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/), zapisivaite, kakie figury ee ispol'zuyut.

**Mozhno li izvlech' izobrazheniya, vlozhennye v OLE-obyekty, naprimer vkladyvannye dokumenty?**

Ne neposredstvenno, poskol'ku OLE-obyekt yavlyaetsya konteynerom. Neobhodimo izvlech' sam OLE-paket, a zatem proanalizirovat' ego soderzhanie s pomoshch'yu otdel'nyh instrumentov. Izobrazheniya v prezentacii rabotajut cherez [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/); OLE - eto drugoj tip obyekta.