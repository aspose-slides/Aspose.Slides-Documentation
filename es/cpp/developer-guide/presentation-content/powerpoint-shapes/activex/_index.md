---
title: Gestionar controles ActiveX en presentaciones usando C++
linktitle: ActiveX
type: docs
weight: 80
url: /es/cpp/activex/
keywords:
- ActiveX
- control ActiveX
- gestionar ActiveX
- añadir ActiveX
- modificar ActiveX
- reproductor multimedia
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Editar cuadros de texto y botones ActiveX, actualizar vistas previas de los controles y reutilizar un control Windows Media Player en presentaciones de PowerPoint con Aspose.Slides para C++."
---
## **Introducción**

Los controles ActiveX proporcionan a una diapositiva de PowerPoint elementos interactivos como cuadros de texto, botones de comando y reproductores multimedia. Aspose.Slides para C++ expone los controles de una diapositiva a través de [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Utilice esta colección para editar un control, moverlo en la diapositiva o eliminarlo.

## **Enumerar controles ActiveX y sus propiedades almacenadas**

Para inspeccionar una plantilla desconocida, ábrala para lectura e itere sobre los controles de cada diapositiva. El ejemplo informa el número de diapositiva, el nombre del control, [ID de clase](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), y cada par clave‑valor en [propiedades almacenadas](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Lee la presentación sin activar los controles, invocar eventos o macros, cambiar valores o guardar el archivo.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

La salida seleccionada de `ActiveX.pptm` muestra un cuadro de texto y un botón de comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una colección de propiedades vacía aparece como `[]`. Para los controles que usan almacenamiento binario, `get_Properties` puede devolver `nullptr`, que se muestra como `Properties unavailable`. Si solo necesita los nombres, utilice [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) después de comprobar que la colección existe. El informe enumera las propiedades disponibles en la presentación. Un control puede admitir propiedades adicionales en tiempo de ejecución.

## **Modificar controles ActiveX**

El ejemplo espera una presentación con macros habilitados que contenga un cuadro de texto llamado `TextBox1` y un botón de comando llamado `CommandButton1` en la primera diapositiva. Utiliza la [colección de propiedades del control](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) para cambiar el valor del cuadro de texto y el título del botón. Cada control también tiene una vista previa estática que PowerPoint puede mostrar antes de la activación. Proporcione un PNG para cada control que muestre su texto y apariencia actualizados. El ejemplo asigna estas imágenes mediante [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

El ejemplo desplaza cada control en la primera diapositiva 100 puntos hacia abajo modificando su [marco](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Guarda la presentación editada en formato PPTM y luego usa [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) para guardar una segunda copia con todos los controles ActiveX eliminados de esa diapositiva.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **Agregar un control ActiveX de reproductor multimedia**

Para reutilizar un control Windows Media Player configurado, comience con una plantilla cuya primera diapositiva contiene un reproductor llamado `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) copia toda la diapositiva a una nueva presentación. El ejemplo establece la `URL` del reproductor en su [colección de propiedades](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) y guarda la diapositiva clonada como la única diapositiva en la salida. El vídeo permanece externo, por lo que debe elegir una ruta a la que el reproductor pueda acceder durante la reproducción.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Puede Aspose.Slides conservar los controles ActiveX sin ejecutarlos?**

Sí. Aspose.Slides puede leer y guardar los controles, incluidas sus propiedades y posiciones, sin activarlos.

**¿En qué se diferencian los controles ActiveX de los objetos OLE?**

Los controles ActiveX permiten a los usuarios interactuar con una diapositiva, por ejemplo introduciendo texto o pulsando un botón. Un [OLE object](/slides/es/cpp/manage-ole/) permite que una diapositiva contenga o enlace contenido gestionado por otra aplicación, como una hoja de cálculo de Excel.

**¿Los eventos ActiveX seguirán activando macros VBA después de guardar una presentación con Aspose.Slides?**

Guarde la presentación en un formato con macros habilitadas, como PPTM, para conservar su proyecto VBA. PowerPoint para Windows puede ejecutar los manejadores de eventos existentes cuando la configuración de seguridad permite tanto los controles ActiveX como las macros.