---
title: Többszálú feldolgozás az Aspose.Slides for Python-ban
linktitle: Többszálú
type: docs
weight: 200
url: /hu/python-net/multithreading/
keywords:
- többszálú
- több szál
- párhuzamos munkavégzés
- diák konvertálása
- diák képekké
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python .NET többszálú feldolgozással felgyorsítja a PowerPoint és OpenDocument feldolgozást. Fedezze fel a leghatékonyabb gyakorlatokat a prezentációs munkafolyamatok optimalizálásához."
---
## **Bevezetés**

Bár a prezentációk párhuzamos feldolgozása lehetséges (a feldolgozás/betöltés/klónozás mellett), és a legtöbb esetben minden rendben működik, mégis előfordulhat, hogy helytelen eredményeket kap a könyvtár több szálban történő használata esetén.

Javasoljuk, hogy **ne** használjon egyetlen [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt több szálas környezetben, mivel ez kiszámíthatatlan hibákhoz vagy nehezen észlelhető meghibásodásokhoz vezethet.

Nem **biztonságos** betölteni, menteni és/vagy klónozni egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály példányát több szálon. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatokat kell végrehajtania, párhuzamosítani kell a műveleteket több egyetlen szálú folyamat használatával – és mindegyik folyamatnak saját prezentációpéldányt kell használnia.

## **Prezentációs diák képekké konvertálása párhuzamosan**

Tegyük fel, hogy párhuzamosan szeretnénk az összes diát egy PowerPoint prezentációból PNG képekké konvertálni. Mivel nem biztonságos egyetlen `Presentation` példányt több szálon használni, a prezentáció diákot különálló prezentációkra bontjuk, és a diákat párhuzamosan képekké konvertáljuk, minden prezentációt külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan kell ezt megtenni.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Kivonja az i-edik diát egy külön prezentációba.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Átalakítja a diát képpé.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Várja meg, hogy az összes feladat befejeződjön.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Gyakran Ismételt Kérdések**

**Szükséges minden szálban meghívni a licenc beállítást?**

Nem. Elég egyszer elvégezni a folyamat/app domain indítása előtt, mielőtt a szálak elindulnak. Ha a [license setup](/slides/hu/python-net/licensing/) párhuzamosan hívható meg (például a lusta inicializálás során), szinkronizálni kell ezt a hívást, mivel a licenc beállítási metódus maga nem szálbiztos.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

Az „élő” prezentációobjektumok szálak közötti átadása nem ajánlott: használjon minden szálra önálló példányt, vagy előre hozzon létre külön prezentációkat/dialeképes tárolókat minden szál számára. Ez a megközelítés követi az általános ajánlást, miszerint ne osszon meg egyetlen prezentációpéldányt több szál között.

**Biztonságos-e különböző formátumokba (PDF, HTML, képek) történő exportot párhuzamosítani, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányokkal és elkülönített kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerüljük a közös prezentációobjektumok és közös I/O streamek használatát.

**Mit kell tenni a globális betűtípusbeállításokkal (mappák, helyettesítések) több szálas környezetben?**

Inicializálja az összes globális betűtípusbeállítást a szálak indítása előtt, és a párhuzamos munka során ne módosítsa őket. Ez megszünteti a versengést a megosztott betűtípus-erőforrások elérésekor.