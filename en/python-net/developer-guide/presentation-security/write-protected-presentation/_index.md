---
title: Write-Protect Presentations in Python
linktitle: Write Protection
type: docs
weight: 25
url: /python-net/write-protected-presentation/
keywords:
- write protection
- write-protect PowerPoint
- password to modify
- restrict presentation editing
- remove write protection
- validate modification password
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Set, detect, validate, and remove write-protection passwords in PowerPoint PPT and PPTX presentations using Aspose.Slides for Python."
---

## **Introduction**

A write-protection password restricts modification of a presentation but does not encrypt its content. Users can load and view a write-protected presentation without the password. Depending on the application, they may also be able to edit the content and save it under a different name, so write protection should not be treated as a confidentiality mechanism.

An opening password serves a different purpose: it encrypts the presentation and is required to load its content. To encrypt a presentation or validate an opening password, see [Password-Protect Presentations](/slides/python-net/password-protected-presentation/).

The workflows in this article apply to both PPT and PPTX presentations. The examples use PPTX files; when saving to PPT, use the `.ppt` extension and the corresponding PPT save format.

## **Set Write Protection on a Presentation**

Use [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/set_write_protection/) to assign a password for modifying a presentation. Saving the presentation persists the protection setting.

The following example sets write protection on a PPTX presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Load a Write-Protected Presentation**

Because write protection does not encrypt presentation content, no password is required to load the presentation. The password is relevant only when validating authorization to modify the protected presentation.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Do not pass a write-protection password to [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/). That property accepts an opening password for encrypted content. If a presentation has both protection types, supply the opening password to load it and handle the write-protection password separately.

## **Remove Write Protection from a Presentation**

Use [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/remove_write_protection/) to remove the modification restriction, then save the presentation.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Check Whether a Presentation Is Write Protected**

To inspect a file without creating a complete [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance, call [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) and inspect [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_write_protected/). The property uses [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) and returns `NullableBool.TRUE` when write protection is detected.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

The stream overload of [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) provides the same information for a presentation supplied as a stream.

## **Validate a Write-Protection Password**

Use [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/check_write_protection/) to validate a modification password without loading the complete presentation. Check [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_write_protected/) first so that the application requests or validates a password only when write protection is present.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/check_write_protection/) validates only the write-protection password. It does not validate an opening password or determine whether encrypted content can be loaded. Conversely, [PresentationInfo.check_password](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/check_password/) validates only an opening password. If a complete presentation has already been loaded, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/check_write_protection/) provides the equivalent write-protection check through its protection manager.

In production applications, do not log passwords or include them in diagnostic messages. Avoid unnecessary repeated validation attempts, and retain passwords in memory only as long as needed.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Does write protection encrypt a presentation?**

No. It restricts modification but leaves the presentation content available for loading and viewing.

**Is the write-protection password required to open a presentation?**

No. Only an opening password is required to load encrypted presentation content.

**Can a presentation have both an opening password and a write-protection password?**

Yes. Supply the opening password through the load options to open the encrypted presentation, and validate the write-protection password separately when modification authorization is required.
