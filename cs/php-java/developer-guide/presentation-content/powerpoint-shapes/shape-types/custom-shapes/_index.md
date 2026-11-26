---
title: Přizpůsobení tvarů prezentace v PHP
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/php-java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentací v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) pro úpravu existujících tvarů, provádění základních operací úpravy cesty, přidávat nebo odstraňovat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, sestavit tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, prozkoumat prvky tvaru a převést obrysy textu Java AWT na geometrické cesty.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![přehled_obrázek](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřená, nebo otevřená.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a ovládací úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva ovládací úchyty zarovnány a jsou stejně vzdálené od kotevního bodu.
  * U přímého bodu jsou dva ovládací úchyty zarovnány, ale mohou mít různou vzdálenost od kotevního bodu.
* Posun kotevních bodů nebo úprava jejich úchytek mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) z instance [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) můžete použít metodu [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) pro tvary s jednou cestou a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody ve třídě [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Pomocí metod [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) a [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete přečíst [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) pomocí jejího [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a přehrát segmenty na [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Jednoduché operace úpravy**

Použijte následující metody k úpravě geometrické cesty. Přetížené verze, které přijímají index, vloží segment na nultovou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma ovládacími body a koncovým bodem. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním ovládacím bodem a koncovým bodem. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Uzavřít aktuální tvar spojením koncového bodu s počátečním bodem. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Nastavit počáteční bod tvaru. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Odstranit segment na nultovém indexu. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) a použije upravenou cestu s [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a spodní okraj, tažením těchto okrajů dovnitř.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![příklad1_obrázek](custom_shape_1.png)

## **Odstranění bodů z tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nultém indexu 2 pomocí [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Aplikace upravené cesty pomocí [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje konturu tvaru.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![příklad2_obrázek](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a zapuštění; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) a aplikována na obdélníkový tvar pomocí [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), čímž nahradí jeho obrys.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![příklad3_obrázek](custom_shape_3.png)

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) pro horní a spodní třetinu tvaru. Aplikací obou cest pomocí [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) se vytvoří jeden složený tvar s mezerou přes jeho střední třetinu.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![příklad4_obrázek](custom_shape_4.png)

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo), aby vytvořil tvar se zakřivenými rohy dovnitř. Každá velikost rohu nastavuje šířku a výšku oblouku v bodech a -90° oblouk vykresluje proti směru hodinových ručiček čtvrtkroužek. Dokončená cesta je použita pomocí [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), a prezentace je uložena ve formátu PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zjištění, zda je geometrie tvaru uzavřená**

Následující pomocná funkce kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Čte [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) a porovnává příkaz posledního segmentu [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) s [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Vrátí false, když neexistují neprázdné cesty. Kontroluje poslední příkaz každé cesty; neprozkoumává každou podfiguru v rámci cesty. Příklad vypíše `true` pro obdélník.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Prohlížení příkazů geometrické cesty**

Stáhněte [contour.pptx](contour.pptx) a umístěte jej do pracovního adresáře aplikace. První tvar na první snímku má rovnou horní hranu, kubickou Bézierovu křivku a rovnou uzavírací hranu. Použijte [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) k načtení cest tvaru a [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) k načtení segmentů každé cesty v pořadí kreslení. Pro každý segment [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) určuje příkaz a stanovuje, jak interpretovat hodnoty vrácené metodou [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

Tvar leží na souřadnicích (200, 100) bodů na snímku. Uvedené souřadnice jsou lokální k tvaru, s (0, 0) v jeho levém horním rohu, x roste doprava a y směrem dolů. Uzavírací segment se vrací na počáteční bod bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![Tvar PowerPoint s rovným horním okrajem, zakřiveným okrajem z pravého horního do levého dolního a rovným levým okrajem](contour.png)

## **Extrahování a prohlížení prvků tvaru**

Použijte [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements), abyste prozkoumali existující tvar jako prvky obsahující body cesty a typy bodů. Každý vrácený [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) použijte k získání polí bodů a typů pomocí metod [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) a [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Toto zobrazení je užitečné pro analýzu kontur nebo předávání geometrie do vlastních kreslících nástrojů.

Příklad otevře input.pptx, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Nepřepočítává uvnitř skupin.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Zachovat typ segmentu, vyjma příznaků.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Spotřebovat oba řídící body a koncový bod.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Pole odpovídají podle indexu: `$points[$i]` je bod a `$types[$i]` popisuje jeho roli. Typ `0` začíná tvar, typ `1` kreslí čáru od předchozího bodu k aktuálnímu bodu. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva ovládací body následované novým koncovým bodem. Smyčka tyto tři položky zpracuje najednou a kontroluje koncový bod pro uzavření.

Typy bodů také obsahují příznaky. Maskujte pomocí `0x07` pro určení typu segmentu a testujte `0x80` samostatně pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. PHP/Java Bridge vrací pole bajtů jako binární řetězec; rozbalení pomocí "C*" vytváří neoznačené bajtové hodnoty. Maskování zachovává zamýšlené bitové hodnoty. Porovnání surové hodnoty pouze s `1` nebo `3` by tyto případy přehlédlo. Další příznaky, jako čára (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y směrem dolů. Pro neagroupovaný tvar již extrahované souřadnice zahrnují pozici vrácenou metodou [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) a [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY), a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník na `(100, 200)` s rozměry `120 × 80` má ohraničení kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y pro získání souřadnic relativně k jeho neotočenému rámu.

Extrahované body neaplikují rotaci tvaru, vrácenou metodou [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), ani horizontální a vertikální převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. U seskupených tvarů také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné souřadnice na snímku ani neaplikujte překlad nebo měřítko dvakrát, pokud už jsou zahrnuty v rámci dítěte.

**Prohlížení vs úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Tento přístup použijte, když vaše analytické nebo kreslicí kódy potřebují pole bodů a typů. Použijte [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), pokud potřebujete příkazy geometrie v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Upravené cesty aplikujte pomocí [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) nebo [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Převod Java AWT Shape na GeometryPath**

Tento příklad kombinuje obdélníkový obrys s textem převedeným na geometrii. Metoda [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) obrysu vypíná výplň. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) vytvoří obrys textu v [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) poskytuje segmenty posunu, čáry, kvadratické, kubické a uzavírací, které příklad přehraje na [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Příklad používá pole float v Javě, aby PHP/Java Bridge zachovalo souřadnice zapsané iterátorem. Text používá písmo Arial o velikosti 40 bodů. Obrys je posunut o 20 bodů horizontálně a umístěn tak, že jeho vizuální horní část je 10 bodů pod horním okrajem tvaru. Cesta textu je vyplněná, zatímco původní obdélník zůstává obrysem. Aplikací obou cest pomocí [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) se vytvoří jeden tvar obsahující obdélník i text.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![příklad5_obrázek](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze kontura. Výplň a obrys se automaticky použijí na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána se souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou [slide](/slides/cs/php-java/convert-powerpoint-to-png/) oblast nebo samotný [shape](/slides/cs/php-java/create-shape-thumbnails/) do rastrového formátu; to zjednodušuje další práci s komplexními geometriemi.