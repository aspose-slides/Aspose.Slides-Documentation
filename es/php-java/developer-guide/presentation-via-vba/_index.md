---
title: Presentación a través de VBA
type: docs
weight: 250
url: /php-java/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, agregar macro, eliminar macro, agregar VBA, eliminar VBA, extraer macro, extraer VBA, macro de PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Agregar, eliminar y extraer macros VBA en presentaciones de PowerPoint"
---

{{% alert title="Nota" color="warning" %}} 

Cuando conviertes una presentación que contiene macros a un formato de archivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas las macros (las macros no se transfieren al archivo resultante).

Cuando agregas macros a una presentación o vuelves a guardar una presentación que contiene macros, Aspose.Slides simplemente escribe los bytes de las macros.

Aspose.Slides **nunca** ejecuta las macros en una presentación.

{{% /alert %}}

## **Agregar Macros VBA**

Aspose.Slides proporciona la clase [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) para permitirte crear proyectos VBA (y referencias de proyecto) y editar módulos existentes. Puedes usar la interfaz [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) para gestionar el VBA integrado en una presentación.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Utiliza el constructor [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) para agregar un nuevo proyecto VBA.
1. Agrega un módulo al VbaProject.
1. Establece el código fuente del módulo.
1. Agrega referencias a <stdole>.
1. Agrega referencias a **Microsoft Office**.
1. Asocia las referencias con el proyecto VBA.
1. Guarda la presentación.

Este código PHP te muestra cómo agregar una macro VBA desde cero a una presentación:

```php
  # Crea una instancia de la clase presentation
  $pres = new Presentation();
  try {
    # Crea un nuevo proyecto VBA
    $pres->setVbaProject(new VbaProject());
    # Agrega un módulo vacío al proyecto VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Módulo");
    # Establece el código fuente del módulo
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Crea una referencia a <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Crea una referencia a Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Agrega referencias al proyecto VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Guarda la presentación
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Puede que quieras revisar **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), que es una aplicación web gratuita utilizada para eliminar macros de documentos de PowerPoint, Excel y Word. 

{{% /alert %}} 

## **Eliminar Macros VBA**

Usando la propiedad [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) en la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), puedes eliminar una macro VBA.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
1. Accede al módulo Macro y elimínalo.
1. Guarda la presentación modificada.

Este código PHP te muestra cómo eliminar una macro VBA:

```php
  # Carga la presentación que contiene la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Accede al módulo Vba y lo elimina
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Guarda la presentación
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extraer Macros VBA**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) y carga la presentación que contiene la macro.
2. Verifica si la presentación contiene un proyecto VBA.
3. Recorre todos los módulos contenidos en el proyecto VBA para ver las macros.

Este código PHP te muestra cómo extraer macros VBA de una presentación que contiene macros:

```php
  # Carga la presentación que contiene la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Verifica si la presentación contiene un proyecto VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```