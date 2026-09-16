---
title: Manage Presentation Hyperlinks on Android
linktitle: Manage Hyperlinks
type: docs
weight: 20
url: /androidjava/manage-hyperlinks/
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
- Android
- Java
- Aspose.Slides
description: "Add, format, update, and remove hyperlinks in PowerPoint and OpenDocument presentations with Aspose.Slides for Android via Java, using Java examples."
---

## **Introduction**

A hyperlink connects presentation content to a website or a location within the presentation. In PowerPoint, hyperlinks commonly serve two purposes:

* Open a website from text, a shape, or a media frame.
* Navigate to another slide, for example, from a table of contents.

Aspose.Slides for Android via Java lets you add these links, control their appearance and sound, update their properties, and remove them. The examples below show how to work with hyperlinks on individual elements and how to access hyperlinks at the presentation, slide, or text-frame level.

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Add URL Hyperlinks**

You can assign a website URL to text, a shape, or a media frame. The element to which you assign the hyperlink determines the clickable area: a text portion links the selected text, while a shape or frame links the slide object.

### **Add URL Hyperlinks to Text**

To link text to a website, pass a [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) to the text portion's [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) method, as shown below. Only that portion of text becomes clickable.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Add URL Hyperlinks to Shapes and Media Frames**

To make a shape or frame clickable, call its [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) method. The hyperlink belongs to the object itself rather than to a text portion inside it.

The same approach applies to picture, audio, and video frames: assign the hyperlink to the frame and call [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) if needed.

The following example makes a rectangle clickable:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Hyperlinks to Create a Table of Contents**

Internal hyperlinks let readers jump from a table of contents to a specific slide. The following example uses [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) to link the “Page 2” text on the first slide to the second slide.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Hyperlinks**

### **Color**

The [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) method of [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) determines whether a hyperlink uses the presentation's hyperlink color or the text portion's formatting. To apply a custom text color, select [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) and set the portion's fill color. This feature was introduced in PowerPoint 2019; older versions do not apply this setting.

The following example adds two text hyperlinks to the same slide. The first uses a red text fill, while the second retains the default hyperlink color.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sound**

A hyperlink can play a sound when activated or stop a sound that is already playing. Use the following methods to configure these behaviors:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specifies the audio associated with the hyperlink.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) controls whether activating the hyperlink stops the previous sound.

#### **Add a Hyperlink Sound**

The following example loads `sampleaudio.wav` and associates it with a button on the first slide. Clicking the button plays the sound and navigates to the next slide. A second shape on that slide stops the previous sound when clicked, without performing a navigation action.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Extract a Hyperlink Sound**

The following example opens the presentation created above and reads the first shape's hyperlink audio into memory through [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) and [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip and Interaction Settings**

You can call the following [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) methods after assigning a hyperlink to text or a shape:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) sets the text that a viewer can display as a hint for the link.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) specifies the target frame within a parent HTML frameset, when applicable.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) controls whether activating the link adds its destination to the list of viewed hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) controls whether the hyperlink is highlighted when clicked.

## **Remove Hyperlinks from Presentations**

Use [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) to collect hyperlink containers, including text-portion links, before changing them. The following example removes both activation types from the first slide. To remove only one type, call only [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) or [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); removing a click action does not remove its mouse-over counterpart.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

For unconditional removal, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) removes both activation types in the selected scope in one call. For selective cleanup and coverage of masters, layouts, and notes, see [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Before distributing a presentation, inventory its interactive actions as well as its web links. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) returns [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) objects, not a flat list of URL strings. Inspect both [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) and [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) on each container. They are independent: the same container can expose both actions, so a complete report needs up to two rows per container.

Scanning only shape-level hyperlinks can miss links attached to text portions. Query the appropriate scope instead, and retain the returned containers so that you can later update or remove their actions.

### **Query Presentation, Slide, and Text-Frame Scopes**

The [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) interface is available through [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), and [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Each scope supports the same queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) returns containers with a click action.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) returns containers with a mouse-over action.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) returns containers with either or both actions.

The following example creates `hyperlink-audit-input.pptx` with an external click link, a file mouse-over link, internal slide navigation, a text mouse-over link, and a macro action. It does not execute any of these actions. The same three queries work at every scope; the counts describe containers, not action totals. The text-frame scope excludes the enclosing shape's own links.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For this example, presentation and slide queries each report three click containers, two mouse-over containers, and three containers with either action. The text-frame query reports one container in each category.

### **Classify Actions and Destinations**

Use [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) to interpret an action before interpreting its destination. The [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) values cover more than web navigation:

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

Read external destinations from [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) and specific internal destinations from [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Internal actions and built-in commands may have no external URL; an empty URL does not mean that the container has no action. Preserve the value returned by [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) when it differs from the normalized URL, and include the tooltip returned by [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) when available.

### **Report, Sanitize, and Verify Hyperlinks**

The following Java example reads an existing presentation (use the file created above), writes `hyperlink-audit.json`, applies a policy, saves `hyperlink-sanitized.pptx`, and reopens it to check both activation types again. It collects containers before changing them and uses reference equality to avoid processing the same container twice. Presentation queries cover ordinary slides; for a package-wide inventory, it also explicitly queries masters, layouts, notes, and the notes and handout masters when present.

The report records a one-based slide index and [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) where available. [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) supplies the owning slide for supported containers. Masters, layouts, and notes have no ordinary slide index and are identified by their scope. Shape containers and text-portion formatting containers are labeled separately; other container types retain their runtime type name. Each container gets a report-local ID so its two actions can be correlated. The report stores action types as the integer constants defined by the Java enumeration.

This deliberately restrictive application policy allows only absolute HTTPS URLs and valid internal slide targets. It rejects macros, programs, file actions, other slideshow actions, unknown actions, and other URL schemes. These rejections are policy decisions, not an Aspose.Slides safety verdict. HTTPS alone does not establish trust: add host allowlists and other checks for your application. Both original and normalized external URLs are checked. The example audits metadata without following links or running actions.

For remediation, the container's [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) supports [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), and [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Here, prohibited external click links are replaced with a fixed HTTPS landing page; other prohibited clicks and prohibited mouse-over actions are removed independently. Set `replaceExternalClicks` to `false` to remove all policy violations instead. Choose an application-owned replacement page before deployment.

The report's export flag uses a conservative PDF review policy: flag mouse-over actions and anything other than an external link or specific slide jump as potentially unsupported. It is a review hint, not a capability test or a guarantee that unflagged links will survive export. Supported [PDF](/slides/androidjava/convert-powerpoint-to-pdf/) and [HTML](/slides/androidjava/convert-powerpoint-to-html/) exports may preserve hyperlinks, depending on the action, export options, and viewer. Raster [images](/slides/androidjava/convert-powerpoint-to-png/) and [video](/slides/androidjava/convert-powerpoint-to-video/) cannot preserve interactive hyperlinks; flag every action when auditing for those outputs.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serialize this report's flat rows without an additional JSON dependency.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

With the input created above, the report contains five action rows. The file mouse-over link and macro click are removed, while the HTTPS links and internal slide navigation remain. The verification prints zero prohibited actions. An input containing a prohibited external click URL also exercises the replacement branch. A container with an allowed click and a prohibited mouse-over keeps its click action.

This selective cleanup differs from [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), which removes both activation types throughout the selected scope regardless of policy. Verification here checks hyperlink actions only; it does not remove embedded VBA projects, OLE objects, or other active content, and it does not validate an exported PDF or HTML file.

## **FAQ**

**How can I link to a section or its first slide?**

Sections in PowerPoint group slides, but an internal hyperlink targets an individual slide. To create navigation to a section, link to the first slide in that section.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Yes. Master slide and layout elements support hyperlinks. Links on these elements are available during the slide show on slides that use the corresponding master or layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Supported PDF and HTML exports may preserve hyperlinks; raster images and video cannot. See the export considerations in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).
