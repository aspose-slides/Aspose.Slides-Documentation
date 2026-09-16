---
title: Manage Presentation Hyperlinks in PHP
linktitle: Manage Hyperlinks
type: docs
weight: 20
url: /php-java/manage-hyperlinks/
keywords:
- add URL
- add hyperlink
- create hyperlink
- format hyperlink
- remove hyperlink
- update hyperlink
- text hyperlink
- slide hyperlink
- shape hyperlink
- image hyperlink
- video hyperlink
- mutable hyperlink
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Add, format, update, and remove hyperlinks in PowerPoint and OpenDocument presentations with Aspose.Slides for PHP via Java, using PHP examples."
---

## **Introduction**

A hyperlink connects presentation content to a website or a location within the presentation. In PowerPoint, hyperlinks commonly serve two purposes:

* Open a website from text, a shape, or a media frame.
* Navigate to another slide, for example, from a table of contents.

Aspose.Slides for PHP via Java lets you add these links, control their appearance and sound, update their properties, and remove them. The examples below show how to work with hyperlinks on individual elements and how to access hyperlinks at the presentation, slide, or text-frame level. They assume that PHP/Java Bridge and the Aspose.Slides PHP wrapper are initialized. API members without a PHP reference page link to the underlying Java API.

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Add URL Hyperlinks**

You can assign a website URL to text, a shape, or a media frame. The element to which you assign the hyperlink determines the clickable area: a text portion links the selected text, while a shape or frame links the slide object.

### **Add URL Hyperlinks to Text**

To link text to a website, pass a [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) to the text portion's [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) method, as shown below. Only that portion of text becomes clickable.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Add URL Hyperlinks to Shapes and Media Frames**

To make a shape or frame clickable, call its [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) method. The hyperlink belongs to the object itself rather than to a text portion inside it.

The same approach applies to picture, audio, and video frames: assign the hyperlink to the frame and call [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) if needed.

The following example makes a rectangle clickable:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Use Hyperlinks to Create a Table of Contents**

Internal hyperlinks let readers jump from a table of contents to a specific slide. The following example uses [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) to link the “Page 2” text on the first slide to the second slide.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Format Hyperlinks**

### **Color**

The [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) method of [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) determines whether a hyperlink uses the presentation's hyperlink color or the text portion's formatting. To apply a custom text color, select [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) and set the portion's fill color. This feature was introduced in PowerPoint 2019; older versions do not apply this setting.

The following example adds two text hyperlinks to the same slide. The first uses a red text fill, while the second retains the default hyperlink color.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Sound**

A hyperlink can play a sound when activated or stop a sound that is already playing. Use the following methods to configure these behaviors:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) specifies the audio associated with the hyperlink.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) controls whether activating the hyperlink stops the previous sound.

#### **Add a Hyperlink Sound**

The following example loads `sampleaudio.wav` and associates it with a button on the first slide. Clicking the button plays the sound and navigates to the next slide. A second shape on that slide stops the previous sound when clicked, without performing a navigation action.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Extract a Hyperlink Sound**

The following example opens the presentation created above and reads the first shape's hyperlink audio into memory through [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) and [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Tooltip and Interaction Settings**

You can call the following [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) methods after assigning a hyperlink to text or a shape:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) sets the text that a viewer can display as a hint for the link.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) specifies the target frame within a parent HTML frameset, when applicable.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) controls whether activating the link adds its destination to the list of viewed hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) controls whether the hyperlink is highlighted when clicked.

## **Remove Hyperlinks from Presentations**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) to collect hyperlink containers, including text-portion links, before changing them. The following example removes both activation types from the first slide. To remove only one type, call only [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) or [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); removing a click action does not remove its mouse-over counterpart.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

For unconditional removal, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) removes both activation types in the selected scope in one call. For selective cleanup and coverage of masters, layouts, and notes, see [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Before distributing a presentation, inventory its interactive actions as well as its web links. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) returns [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) objects, not a flat list of URL strings. Inspect both [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) and [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) on each container. They are independent: the same container can expose both actions, so a complete report needs up to two rows per container.

Scanning only shape-level hyperlinks can miss links attached to text portions. Query the appropriate scope instead, and retain the returned containers so that you can later update or remove their actions.

### **Query Presentation, Slide, and Text-Frame Scopes**

The [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) class is available through [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), and [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). Each scope supports the same queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) returns containers with a click action.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) returns containers with a mouse-over action.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) returns containers with either or both actions.

The following example creates `hyperlink-audit-input.pptx` with an external click link, a file mouse-over link, internal slide navigation, a text mouse-over link, and a macro action. It does not execute any of these actions. The same three queries work at every scope; the counts describe containers, not action totals. The text-frame scope excludes the enclosing shape's own links.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

For this example, presentation and slide queries each report three click containers, two mouse-over containers, and three containers with either action. The text-frame query reports one container in each category.

### **Classify Actions and Destinations**

Use [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) to interpret an action before interpreting its destination. The [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) values cover more than web navigation:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | External hyperlink; inspect the URL and its scheme. |
| `JumpSpecificSlide` | Internal navigation to a particular slide. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Built-in slideshow navigation, resolved in slideshow context. |
| `JumpEndShow`, `StartCustomSlideShow` | End the current show or start a custom show. |
| `StartMacro` | Execute a macro. |
| `StartProgram` | Launch a program. |
| `OpenFile`, `OpenPresentation` | Open a file or another presentation; review separately from web URLs. |
| `StartStopMedia` | Start or stop media playback. |
| `NoAction`, `Unknown` | No navigation action, or an unrecognized action requiring review. |

Read external destinations from [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) and specific internal destinations from [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). Internal actions and built-in commands may have no external URL; an empty URL does not mean that the container has no action. Preserve the value returned by [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) when it differs from the normalized URL, and include the tooltip returned by [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) when available.

### **Report, Sanitize, and Verify Hyperlinks**

The following PHP example reads an existing presentation (use the file created above), writes `hyperlink-audit.json`, applies a policy, saves `hyperlink-sanitized.pptx`, and reopens it to check both activation types again. It collects containers before changing them and uses reference equality to avoid processing the same container twice. Presentation queries cover ordinary slides; for a package-wide inventory, it also explicitly queries masters, layouts, notes, and the notes and handout masters when present.

The report records a one-based slide index and [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) where available. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) supplies the owning slide for supported containers. Masters, layouts, and notes have no ordinary slide index and are identified by their scope. Shape containers and text-portion formatting containers are labeled separately; other container types retain their runtime type name. Each container gets a report-local ID so its two actions can be correlated. The report stores action types as the integer constants defined by the PHP enumeration.

This deliberately restrictive application policy allows only absolute HTTPS URLs and valid internal slide targets. It rejects macros, programs, file actions, other slideshow actions, unknown actions, and other URL schemes. These rejections are policy decisions, not an Aspose.Slides safety verdict. HTTPS alone does not establish trust: add host allowlists and other checks for your application. Both original and normalized external URLs are checked. The example audits metadata without following links or running actions.

For remediation, the container's [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) supports [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), and [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Here, prohibited external click links are replaced with a fixed HTTPS landing page; other prohibited clicks and prohibited mouse-over actions are removed independently. Set `$replaceExternalClicks` to `false` to remove all policy violations instead. Choose an application-owned replacement page before deployment.

The report's export flag uses a conservative PDF review policy: flag mouse-over actions and anything other than an external link or specific slide jump as potentially unsupported. It is a review hint, not a capability test or a guarantee that unflagged links will survive export. Supported [PDF](/slides/php-java/convert-powerpoint-to-pdf/) and [HTML](/slides/php-java/convert-powerpoint-to-html/) exports may preserve hyperlinks, depending on the action, export options, and viewer. Raster [images](/slides/php-java/convert-powerpoint-to-png/) and [video](/slides/php-java/convert-powerpoint-to-video/) cannot preserve interactive hyperlinks; flag every action when auditing for those outputs.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

With the input created above, the report contains five action rows. The file mouse-over link and macro click are removed, while the HTTPS links and internal slide navigation remain. The verification prints zero prohibited actions. An input containing a prohibited external click URL also exercises the replacement branch. A container with an allowed click and a prohibited mouse-over keeps its click action.

This selective cleanup differs from [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), which removes both activation types throughout the selected scope regardless of policy. Verification here checks hyperlink actions only; it does not remove embedded VBA projects, OLE objects, or other active content, and it does not validate an exported PDF or HTML file.

## **FAQ**

**How can I link to a section or its first slide?**

Sections in PowerPoint group slides, but an internal hyperlink targets an individual slide. To create navigation to a section, link to the first slide in that section.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Yes. Master slide and layout elements support hyperlinks. Links on these elements are available during the slide show on slides that use the corresponding master or layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Supported PDF and HTML exports may preserve hyperlinks; raster images and video cannot. See the export considerations in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).
