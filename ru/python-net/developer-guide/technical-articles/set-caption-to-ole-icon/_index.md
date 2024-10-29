---
title: Установка заголовка для OLE-значка
type: docs
weight: 160
url: /ru/python-net/set-caption-to-ole-icon/
---

Новое свойство **SubstitutePictureTitle** было добавлено к интерфейсу **IOleObjectFrame** и классу **OleObjectFrame**. Оно позволяет получать, устанавливать или изменять заголовок OLE-значка. Приведенный ниже фрагмент кода демонстрирует пример создания объекта Excel и установки его заголовка.

```py
import aspose.pydrawing as draw
import aspose.slides as slides


def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Добавить OLE-объекты
    allbytes = read_all_bytes("oleSourceFile.bin")
    dataInfo = slides.dom.ole.OleEmbeddedDataInfo(allbytes, "xls")
    
    oof = slide.shapes.add_ole_object_frame(20, 20, 50, 50, dataInfo)
    oof.is_object_icon = True

    # Добавить объект изображения
    imgBuf = read_all_bytes("oleIconFile.ico")
    with open("oleIconFile.ico", "rb") as stream:
        image = pres.images.add_image(slides.Bitmap(stream))
        oof.substitute_pictureFormat.picture.image = image

    # Установить заголовок для OLE-значка
    oof.substitute_picture_title = "Пример заголовка"
```