---
title: Fuente incrustada
type: docs
weight: 40
url: /es/cpp/embedded-font/
keywords: "Fuentes, fuentes incrustadas, añadir fuentes, presentación de PowerPoint C++, CPP, Aspose.Slides para C++"
description: "Usar fuentes incrustadas en la presentación de PowerPoint en C++"
---

**Las fuentes incrustadas en PowerPoint** son útiles cuando deseas que tu presentación se vea correctamente al abrirse en cualquier sistema o dispositivo. Si usaste una fuente de terceros o no estándar porque te diste un gusto en tu trabajo, entonces tienes aún más razones para incrustar tu fuente. De lo contrario (sin fuentes incrustadas), los textos o números en tus diapositivas, el diseño, el estilo, etc. pueden cambiar o convertirse en rectángulos confusos.

La clase [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/), la clase [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/), la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) y sus interfaces contienen la mayoría de las propiedades y métodos que necesitas para trabajar con fuentes incrustadas en presentaciones de PowerPoint.

## **Obtener o eliminar fuentes incrustadas de la presentación**

Aspose.Slides proporciona el método [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) (expuesto por la clase [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/)) para permitirte obtener (o averiguar) las fuentes incrustadas en una presentación. Para eliminar fuentes, se utiliza el método [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) (expuesto por la misma clase).

Este código C++ muestra cómo obtener y eliminar fuentes incrustadas de una presentación:

```c++
// Instancia un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// Renderiza una diapositiva que contiene un marco de texto que usa "FunSized" incrustado
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// Obtiene todas las fuentes incrustadas
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// Encuentra la fuente "Calibri"
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// Elimina la fuente "Calibri"
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// Renderiza la presentación; la fuente "Calibri" es reemplazada por una existente
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::Png);

// Guarda la presentación sin la fuente "Calibri" incrustada en disco
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **Añadir fuentes incrustadas a la presentación**

Usando el enum [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) y dos sobrecargas del método [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/), puedes seleccionar tu regla preferida (de incrustación) para incrustar las fuentes en una presentación. Este código C++ muestra cómo incrustar y añadir fuentes a una presentación:

```c++
// Carga la presentación
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carga la fuente de origen que se reemplazará
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// Guarda la presentación en disco
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **Comprimir fuentes incrustadas**

Para permitirte comprimir las fuentes incrustadas en una presentación y reducir su tamaño de archivo, Aspose.Slides proporciona el método [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) (expuesto por la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)).

Este código C++ muestra cómo comprimir fuentes de PowerPoint incrustadas:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```