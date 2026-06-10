---
title: SmartArt alakzat csomópontok kezelése előadásokban Python használatával
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/python-net/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- segédcsomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a SmartArt alakzat csomópontokat PPT, PPTX és ODP formátumokban az Aspose.Slides for Python via .NET segítségével. Szerezzen világos kódpéldákat és tippeket a prezentációk hatékonyabbá tételéhez."
---
## **Overview**

A PowerPoint előadásban a SmartArt grafikákat olyan csomópontok szervezik, amelyek szöveget tartalmaznak és meghatározzák a diagram szerkezetét. Az Aspose.Slides lehetővé teszi, hogy programozottan dolgozzon ezen SmartArt csomópontokkal: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása adott pozícióba, meglévő csomópontok elérése, valamint a szövegük, szintjük és pozíciójuk olvasása.

Ez a cikk bemutatja, hogyan kezelje a SmartArt alakzat csomópontjait. Megmutatja, hogyan távolítson el csomópontokat, hogyan dolgozzon gyermekcsomópontokkal index vagy pozíció alapján, hogyan változtassa a segédcsomópontot normál csomóponttá, hogyan állítsa be a SmartArt csomópont alakzatok pozícióját, méretét és forgását, hogyan állítsa be a csomópont kitöltési formátumát, valamint hogyan generáljon bélyegképet egy SmartArt gyermekcsomóponthoz.

## **Add SmartArt Node**
Az Aspose.Slides for Python via .NET a legegyszerűbb API-t biztosítja a SmartArt alakzatok kezeléséhez a legegyszerűbb módon. Az alábbi mintakód segít csomópont és gyermekcsomópont hozzáadásában a SmartArt alakzaton belül.

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, végezzen típuskonverziót a kiválasztott alakzatra SmartArt típusra.
- Adjon hozzá egy új Csomópontot a SmartArt alakzat NodeCollection-jéhez, és állítsa be a szöveget a TextFrame-ben.
- Ezután adjon hozzá egy Gyermekcsomópontot az újonnan hozzáadott SmartArt Csomóponthoz, és állítsa be a szöveget a TextFrame-ben.
- Mentse el az előadást.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:

        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Új SmartArt csomópont hozzáadása
            node1 = shape.all_nodes.add_node()
            # Szöveg hozzáadása
            node1.text_frame.text = "Test"

            # Új gyermekcsomópont hozzáadása a szülőcsomóponthoz. A gyűjtemény végére kerül hozzáadásra
            new_node = node1.child_nodes.add_node()

            # Szöveg hozzáadása
            new_node.text_frame.text = "New Node Added"

    # Prezentáció mentése
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Add SmartArt Node at Specific Position**
Az alábbi mintakódban bemutattuk, hogyan adhatók hozzá a SmartArt alakzat egyes csomópontjaihoz tartozó gyermekcsomópontok adott pozícióban.

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot a kiválasztott diára.
- Érje el az első csomópontot a hozzáadott SmartArt alakzatban.
- Ezután adjon hozzá egy Gyermekcsomópontot a kiválasztott Csomóponthoz a 2. pozícióban, és állítsa be a szövegét.
- Mentse el az előadást.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Prezentációpéldány létrehozása
with slides.Presentation() as pres:
    # A prezentáció dia elérése
    slide = pres.slides[0]

    # Smart Art IShape hozzáadása
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # SmartArt csomópont elérése indexen 0
    node = smart.all_nodes[0]

    # Új gyermekcsomópont hozzáadása a szülőcsomóponthoz a 2. pozíción
    chNode = node.child_nodes.add_node_by_position(2)

    # Szöveg hozzáadása
    chNode.text_frame.text = "Sample text Added"

    # Prezentáció mentése
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Access SmartArt Node**
Az alábbi mintakód segít a SmartArt alakzaton belüli csomópontok elérésében. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType-ját nem lehet módosítani, mivel csak olvasható, és csak a SmartArt alakzat hozzáadása során állítódik be.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, végezzen típuskonverziót a kiválasztott alakzatra SmartArt típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes Csomóponton.
- Érje el és jelenítse meg az információkat, például a SmartArt Csomópont pozícióját, szintjét és szövegét.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Iteráljon végig a SmartArt összes csomópontján
            for i in range(len(shape.all_nodes)):
                # SmartArt csomópont elérése i indexen
                node = shape.all_nodes[i]

                # SmartArt csomópont paramétereinek kiírása
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Access SmartArt Child Node**
Az alábbi mintakód segít a SmartArt alakzat egyes csomópontjaihoz tartozó gyermekcsomópontok elérésében.

- Hozzon létre egy példányt a PresentationEx osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArtEx típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes Csomóponton.
- Minden kiválasztott SmartArt alakzat Csomópont esetén iteráljon végig az adott csomóponton belüli összes Gyermekcsomóponton.
- Érje el és jelenítse meg az információkat, például a Gyermekcsomópont pozícióját, szintjét és szövegét.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Iteráljon végig a SmartArt összes csomópontján
            for node0 in shape.all_nodes:
                # Gyermekcsomópontok bejárása
                for j in range(len(node0.child_nodes)):
                    # Gyermekcsomópont elérése a SmartArt csomópontban
                    node = node0.child_nodes[j]

                    # SmartArt gyermekcsomópont paramétereinek kiírása
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **Access SmartArt Child Node at Specific Position**
Ebben a példában megtanuljuk, hogyan érhetjük el a SmartArt alakzat egyes csomópontjaihoz tartozó gyermekcsomópontokat egy adott pozícióban.

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot.
- Érje el a hozzáadott SmartArt alakzatot.
- Érje el a 0 indexű csomópontot a kiválasztott SmartArt alakzaton.
- Ezután a GetNodeByPosition() metódussal érje el a 1. pozícióban lévő Gyermekcsomópontot a kiválasztott SmartArt csomóponton.
- Érje el és jelenítse meg az információkat, például a Gyermekcsomópont pozícióját, szintjét és szövegét.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Prezentáció példányosítása
with slides.Presentation() as pres:
    # Az első dia elérése
    slide = pres.slides[0]
    # SmartArt alakzat hozzáadása az első diára
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # SmartArt csomópont elérése indexen 0
    node = smart.all_nodes[0]
    # Gyermekcsomópont elérése a 1. pozícióban a szülőcsomópontban
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt gyermekcsomópont paramétereinek kiírása
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Remove SmartArt Node**
Ebben a példában megtanuljuk, hogyan távolíthatók el a csomópontok a SmartArt alakzaton belül.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, végezzen típuskonverziót a kiválasztott alakzatra SmartArt típusra.
- Ellenőrizze, hogy a SmartArt több mint 0 csomóponttal rendelkezik-e.
- Válassza ki a törlendő SmartArt csomópontot.
- Ezután a RemoveNode() metódussal távolítsa el a kiválasztott csomópontot* Mentse el az előadást.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Típuskonvertálja az alakzatot SmartArtEx típusra
            if len(shape.all_nodes) > 0:
                # SmartArt csomópont elérése indexen 0
                node = shape.all_nodes[0]

                # A kiválasztott csomópont eltávolítása
                shape.all_nodes.remove_node(node)

    # Prezentáció mentése
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove SmartArt Node at Specific Position**
Ebben a példában megtanuljuk, hogyan távolítsuk el a csomópontokat a SmartArt alakzaton belül egy adott pozícióban.

- Hozzon létre egy példányt a `Presentation` osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg az első dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, végezzen típuskonverziót a kiválasztott alakzatra SmartArt típusra.
- Válassza ki a SmartArt alakzat 0 indexű csomópontját.
- Ezután ellenőrizze, hogy a kiválasztott SmartArt csomópontnak több mint 2 gyermekcsomópontja van-e.
- Ezután a RemoveNodeByPosition() metódussal távolítsa el az 1. pozícióban lévő csomópontot.
- Mentse el az előadást.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Típuskonvertálja az alakzatot SmartArt típusra
            if len(shape.all_nodes) > 0:
                # SmartArt csomópont elérése indexen 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # A gyermekcsomópont eltávolítása az 1. pozícióban
                    node.child_nodes.remove_node(1)

    # Prezentáció mentése
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Custom Position for Child Node in SmartArt**
Az Aspose.Slides for Python via .NET most támogatja a SmartArtShape X és Y tulajdonságainak beállítását. Az alábbi kódrészlet megmutatja, hogyan állítsa be az egyéni SmartArtShape pozíciót, méretet és forgást; vegye figyelembe, hogy új csomópontok hozzáadása újraszámítja az összes csomópont pozícióját és méretét.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Töltse be a kívánt prezentációt
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt alakzat áthelyezése új pozícióba
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# SmartArt alakzat szélességének módosítása
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# SmartArt alakzat magasságának módosítása
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# SmartArt alakzat forgatásának módosítása
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Check Assistant Node**
Az alábbi mintakódban megvizsgáljuk, hogyan azonosítsuk a segédcsomópontokat a SmartArt csomópontgyűjteményben, és hogyan módosítsuk őket.

- Hozzon létre egy példányt a PresentationEx osztályból, és töltse be az előadást SmartArt alakzattal.
- Szerezze meg a második dia hivatkozását az Index használatával.
- Iteráljon végig az első dián belüli minden alakzaton.
- Ellenőrizze, hogy az alakzat SmartArt típusú-e, és ha igen, konvertálja a kiválasztott alakzatot SmartArtEx típusra.
- Iteráljon végig a SmartArt alakzaton belüli összes csomóponton, és ellenőrizze, hogy segédcsomópontok-e.
- Módosítsa a segédcsomópont állapotát normál csomóponttá.
- Mentse el az előadást.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Prezentációpéldány létrehozása
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Iteráljon végig az első dián belüli minden alakzaton
    for shape in pres.slides[0].shapes:
        # Ellenőrizze, hogy az alakzat SmartArt típusú-e
        if type(shape) is art.SmartArt:
            # Iteráljon végig a SmartArt alakzat összes csomópontján
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Ellenőrizze, hogy a csomópont segédcsomópont-e
                if node.is_assistant:
                    # A segédcsomópont állapotának false-ra állítása és normál csomóponttá alakítása
                    node.is_assistant = False
    # Prezentáció mentése
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Node's Fill Format**
Az Aspose.Slides for Python via .NET lehetővé teszi egyedi SmartArt alakzatok hozzáadását és azok kitöltési formátumának beállítását. Ez a cikk bemutatja, hogyan hozzunk létre és érjünk el SmartArt alakzatokat, és hogyan állítsuk be a kitöltési formátumukat az Aspose.Slides for Python via .NET használatával.

Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a `Presentation` osztályból.
- Szerezze meg egy dia hivatkozását az indexe alapján.
- Adjon hozzá egy SmartArt alakzatot a LayoutType beállításával.
- Állítsa be a FillFormat-ot a SmartArt alakzat csomópontjaihoz.
- Írja ki a módosított előadást PPTX fájlként.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # A dia elérése
    slide = presentation.slides[0]

    # SmartArt alakzat és csomópontok hozzáadása
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Csomópont kitöltési szín beállítása
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Prezentáció mentése
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Generate Thumbnail of SmartArt Child Node**
A fejlesztők az alábbi lépések követésével generálhatnak bélyegképet egy SmartArt gyermekcsomópontjáról:

1. Példányosítsa a `Presentation` osztályt, amely a PPTX fájlt képviseli.
2. Adjon hozzá SmartArt-ot.
3. Szerezze meg egy csomópont hivatkozását az Index használatával
4. Szerezze meg a bélyegkép képet.
5. Mentse a bélyegkép képet a kívánt képf formátumban.

Az alábbi példa a SmartArt gyermekcsomópont bélyegképének generálását mutatja

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTX fájlt képviselő Presentation osztály példányosítása
with slides.Presentation() as presentation: 
    # SmartArt hozzáadása
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Csomópont hivatkozásának beszerzése az Index használatával
    node = smart.nodes[1]

    # Bélyegkép lekérése
    with node.shapes[0].get_image() as bmp:
        # bélyegkép mentése
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Is SmartArt animation supported?**

Igen. A SmartArt-ot egy standard alakzatként kezelik, így [alkalmazhat szabványos animációkat](/slides/hu/python-net/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgásútvonal) és beállíthatja az időzítést. Szükség esetén animálhatja a SmartArt csomópontok belső alakzatait is.

**How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?**

Rendeljen és keressen [alternatív szöveg](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/alternative_text/) alapján. A SmartArt-ra egy egyedi AltText beállításával programozottan megtalálhatja anélkül, hogy a belső azonosítókra támaszkodna.

**Will the SmartArt appearance be preserved when converting the presentation to PDF?**

Igen. Az Aspose.Slides magas vizuális pontossággal rendereli a SmartArt-ot a [PDF export](/slides/hu/python-net/convert-powerpoint-to-pdf/) során, megőrizve a elrendezést, a színeket és a hatásokat.

**Can I extract an image of the entire SmartArt (for previews or reports)?**

Igen. A SmartArt alakzatot renderelheti [raszteres formátumokra](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/get_image/) vagy [SVG-re](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/write_as_svg/) skálázható vektoros kimenethez, így alkalmas bélyegképekhez, jelentésekhez vagy webes felhasználáshoz.