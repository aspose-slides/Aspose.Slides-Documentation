---
title: Manage Presentation Hyperlinks in Python
linktitle: Manage Hyperlinks
type: docs
weight: 20
url: /python-net/manage-hyperlinks/
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
- Python
- Aspose.Slides
description: "Add, format, update, and remove hyperlinks in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET, using Python examples."
---

## **Introduction**

A hyperlink connects presentation content to a website or a location within the presentation. In PowerPoint, hyperlinks commonly serve two purposes:

* Open a website from text, a shape, or a media frame.
* Navigate to another slide, for example, from a table of contents.

Aspose.Slides for Python via .NET lets you add these links, control their appearance and sound, update their properties, and remove them. The examples below show how to work with hyperlinks on individual elements and how to access hyperlinks at the presentation, slide, or text-frame level.

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **Add URL Hyperlinks**

You can assign a website URL to text, a shape, or a media frame. The element to which you assign the hyperlink determines the clickable area: a text portion links the selected text, while a shape or frame links the slide object.

### **Add URL Hyperlinks to Text**

To link text to a website, assign a [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) to the text portion's [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) property, as shown below. Only that portion of text becomes clickable.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Add URL Hyperlinks to Shapes and Media Frames**

To make a shape or frame clickable, set its [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) property. The hyperlink belongs to the object itself rather than to a text portion inside it.

The same approach applies to picture, audio, and video frames: assign the hyperlink to the frame and set the link's [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) if needed.

The following example makes a rectangle clickable:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Use Hyperlinks to Create a Table of Contents**

Internal hyperlinks let readers jump from a table of contents to a specific slide. The following example uses [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) to link the “Page 2” text on the first slide to the second slide.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Hyperlinks**

### **Color**

The [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) property of [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) determines whether a hyperlink uses the presentation's hyperlink color or the text portion's formatting. To apply a custom text color, select [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) and set the portion's fill color. This feature was introduced in PowerPoint 2019; older versions do not apply this setting.

The following example adds two text hyperlinks to the same slide. The first uses a red text fill, while the second retains the default hyperlink color.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Sound**

A hyperlink can play a sound when activated or stop a sound that is already playing. Use the following properties to configure these behaviors:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) specifies the audio associated with the hyperlink.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) controls whether activating the hyperlink stops the previous sound.

#### **Add a Hyperlink Sound**

The following example loads `sampleaudio.wav` and associates it with a button on the first slide. Clicking the button plays the sound and navigates to the next slide. A second shape on that slide stops the previous sound when clicked, without performing a navigation action.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Extract a Hyperlink Sound**

The following example opens the presentation created above and reads the first shape's hyperlink audio into memory through [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) and [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Tooltip and Interaction Settings**

You can update the following [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) properties after assigning a hyperlink to text or a shape:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) sets the text that a viewer can display as a hint for the link.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) specifies the target frame within a parent HTML frameset, when applicable.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) controls whether activating the link adds its destination to the list of viewed hyperlinks.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) controls whether the hyperlink is highlighted when clicked.

## **Remove Hyperlinks from Presentations**

Use [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) to collect hyperlink containers, including text-portion links, before changing them. The following example removes both activation types from the first slide. To remove only one type, call only [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) or [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); removing a click action does not remove its mouse-over counterpart.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

For unconditional removal, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) removes both activation types in the selected scope in one call. For selective cleanup and coverage of masters, layouts, and notes, see [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Before distributing a presentation, inventory its interactive actions as well as its web links. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returns [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) objects, not a flat list of URL strings. Inspect both [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) and [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) on each container. They are independent: the same container can expose both actions, so a complete report needs up to two rows per container.

Scanning only shape-level hyperlinks can miss links attached to text portions. Query the appropriate scope instead, and retain the returned containers so that you can later update or remove their actions.

### **Query Presentation, Slide, and Text-Frame Scopes**

The [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) class is available through [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/), and [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Each scope supports the same queries:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) returns containers with a click action.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) returns containers with a mouse-over action.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) returns containers with either or both actions.

The following example creates `hyperlink-audit-input.pptx` with an external click link, a file mouse-over link, internal slide navigation, a text mouse-over link, and a macro action. It does not execute any of these actions. The same three queries work at every scope; the counts describe containers, not action totals. The text-frame scope excludes the enclosing shape's own links.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

For this example, presentation and slide queries each report three click containers, two mouse-over containers, and three containers with either action. The text-frame query reports one container in each category.

### **Classify Actions and Destinations**

Use [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) to interpret an action before interpreting its destination. The [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) values cover more than web navigation:

| Values | Meaning for an audit |
| --- | --- |
| `HYPERLINK` | External hyperlink; inspect the URL and its scheme. |
| `JUMP_SPECIFIC_SLIDE` | Internal navigation to a particular slide. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Built-in slideshow navigation, resolved in slideshow context. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | End the current show or start a custom show. |
| `START_MACRO` | Execute a macro. |
| `START_PROGRAM` | Launch a program. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Open a file or another presentation; review separately from web URLs. |
| `START_STOP_MEDIA` | Start or stop media playback. |
| `NO_ACTION`, `UNKNOWN` | No navigation action, or an unrecognized action requiring review. |

Read external destinations from [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) and specific internal destinations from [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Internal actions and built-in commands may have no external URL; an empty URL does not mean that the container has no action. Preserve [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) when it differs from the normalized URL, and include the [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) when available.

### **Report, Sanitize, and Verify Hyperlinks**

The following Python example reads an existing presentation (use the file created above), writes `hyperlink-audit.json`, applies a policy, saves `hyperlink-sanitized.pptx`, and reopens it to check both activation types again. It collects containers before changing them and queries each slide scope once to avoid duplicate processing. Presentation queries cover ordinary slides; for a package-wide inventory, the example queries ordinary slides, masters, layouts, notes, and the notes and handout masters when present.

The report records a one-based slide index and [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) where available. The collector retains the owning slide and scope alongside each returned container. Masters, layouts, and notes have no ordinary slide index and are identified by their scope. Shape containers and text-portion formatting containers are labeled separately; other container types retain their runtime type name. Each container gets a report-local ID so its two actions can be correlated.

This deliberately restrictive application policy allows only absolute HTTPS URLs and valid internal slide targets. It rejects macros, programs, file actions, other slideshow actions, unknown actions, and other URL schemes. These rejections are policy decisions, not an Aspose.Slides safety verdict. HTTPS alone does not establish trust: add host allowlists and other checks for your application. Both original and normalized external URLs are checked. The example audits metadata without following links or running actions.

For remediation, the container's [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) supports [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), and [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Here, prohibited external click links are replaced with a fixed HTTPS landing page; other prohibited clicks and prohibited mouse-over actions are removed independently. Set `replace_external_clicks` to `False` to remove all policy violations instead. Choose an application-owned replacement page before deployment.

The report's export flag uses a conservative PDF review policy: flag mouse-over actions and anything other than an external link or specific slide jump as potentially unsupported. It is a review hint, not a capability test or a guarantee that unflagged links will survive export. Supported [PDF](/slides/python-net/convert-powerpoint-to-pdf/) and [HTML](/slides/python-net/convert-powerpoint-to-html/) exports may preserve hyperlinks, depending on the action, export options, and viewer. Raster [images](/slides/python-net/convert-powerpoint-to-png/) and [video](/slides/python-net/convert-powerpoint-to-video/) cannot preserve interactive hyperlinks; flag every action when auditing for those outputs.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

With the input created above, the report contains five action rows. The file mouse-over link and macro click are removed, while the HTTPS links and internal slide navigation remain. The verification prints zero prohibited actions. An input containing a prohibited external click URL also exercises the replacement branch. A container with an allowed click and a prohibited mouse-over keeps its click action.

This selective cleanup differs from [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), which removes both activation types throughout the selected scope regardless of policy. Verification here checks hyperlink actions only; it does not remove embedded VBA projects, OLE objects, or other active content, and it does not validate an exported PDF or HTML file.

## **FAQ**

**How can I link to a section or its first slide?**

Sections in PowerPoint group slides, but an internal hyperlink targets an individual slide. To create navigation to a section, link to the first slide in that section.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Yes. Master slide and layout elements support hyperlinks. Links on these elements are available during the slide show on slides that use the corresponding master or layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Supported PDF and HTML exports may preserve hyperlinks; raster images and video cannot. See the export considerations in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).
