---
title: Ändra storlek på former i presentationsbilder
type: docs
weight: 100
url: /sv/cpp/re-sizing-shapes-on-slide/
keywords:
- ändra formstorlek
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Ändra enkelt storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för C++ - automatisera justeringar av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för C++‑kunder är hur man ändrar storlek på former så att data inte kapas när bildstorleken ändras. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir felplacerade när bildstorleken ändras, uppdatera varje forms position och dimensioner så att de följer den nya bildlayouten.

```cpp
// Ladda presentationsfilen.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Hämta den ursprungliga bildstorleken.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ändra bildstorleken utan att skala befintliga former.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Hämta den nya bildstorleken.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Skala formens storlek.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala formens storlek.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala formens position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Om en bild innehåller en tabell fungerar koden ovan inte korrekt. I så fall måste varje cell i tabellen ändras i storlek. 
{{% /alert %}} 

Använd följande kod för att ändra storlek på bilder som innehåller tabeller. För tabeller är det ett särskilt fall att sätta bredd eller höjd: du måste justera enskilda radhöjder och kolumnbredder för att ändra tabellens totala storlek.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Hämta den ursprungliga bildstorleken.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ändra bildstorleken utan att skala befintliga former.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Hämta den nya bildstorleken.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skala formens storlek.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala formens position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skala formens storlek.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skala formens position.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala formens storlek.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala formens position.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avkapade efter att en bild har ändrats i storlek?**

När en bild ändras i storlek behåller former sina ursprungliga position och storlek om skalan inte uttryckligen ändras. Detta kan leda till att innehållet kapas eller att former blir felplacerade.

**Fungerar den medföljande koden för alla formtyper?**

Det grundläggande exemplet fungerar för de flesta formtyper (textrutor, bilder, diagram osv.). För tabeller måste du dock hantera rader och kolumner separat, eftersom höjden och bredden på en tabell bestäms av dimensionerna på enskilda celler.

**Hur ändrar jag storlek på tabeller när jag ändrar bildens storlek?**

Du måste loopa igenom alla rader och kolumner i tabellen och ändra deras höjd och bredd proportionellt, som visas i det andra kodexemplet.

**Fungerar denna storleksändring för masternbilder och layoutbilder?**

Ja, men du bör också loopa igenom [Masterna](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_masters/) och [Layoutbilder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_layoutslides/) och tillämpa samma skalningslogik på deras former för att säkerställa konsekvens i hela presentationen.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Du kan använda [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidesize/set_orientation/) för att ändra orienteringen. Se till att du anpassar skalningslogiken därefter för att bevara layouten.

**Finns det någon gräns för den bildstorlek jag kan ange?**

Aspose.Slides stödjer anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

**Hur kan jag förhindra att former med låst bildförhållande blir förvrängda?**

Du kan kontrollera metoden `get_AspectRatioLocked` för formen innan du skalar. Om den är låst, justera bredd eller höjd proportionellt i stället för att skala dem individuellt.