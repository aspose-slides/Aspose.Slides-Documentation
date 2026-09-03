---
title: ฝังแบบอักษรในงานนำเสนอด้วย Python
linktitle: แบบอักษรที่ฝังไว้
type: docs
weight: 40
url: /th/python-net/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- รับแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการแบบอักษรที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ใช้ Python เพื่อเพิ่ม, ดึง, ลบและบีบอัดแบบอักษรเพื่อรักษาลักษณะข้อความและลดขนาดไฟล์."
---
## **บทนำ**

การฝังแบบอักษรจะเก็บข้อมูลแบบอักษรไว้ภายในไฟล์ PowerPoint เมื่อโปรแกรมดูรองรับการฝังแบบอักษร มันจะสามารถแสดงข้อความโดยใช้แบบอักษรเหล่านั้นได้แม้ไม่ได้ติดตั้งบนระบบเป้าหมาย ซึ่งช่วยรักษาการตัดบรรทัด การจัดช่องว่างของข้อความและการจัดวางสไลด์

Aspose.Slides for Python via .NET ให้คุณดึง, เพิ่มและลบแบบอักษรที่ฝังไว้ผ่านคุณสมบัติ [fonts_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/fonts_manager/) ของอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณยังสามารถลดขนาดข้อมูลแบบอักษรที่ฝังด้วยการลบอักขระที่ไม่ได้ใช้ในงานนำเสนอได้อีกด้วย

ตัวอย่างต่อไปนี้ทำงานกับไฟล์ PPTX ก่อนที่จะแฝงแบบอักษร ให้ตรวจสอบว่าข้อมูลแบบอักษรพร้อมใช้งานสำหรับ Aspose.Slides และใบอนุญาตของแบบอักษรอนุญาตให้ฝังได้

## **รับและลบแบบอักษรที่ฝังไว้**

ใช้ [get_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) เพื่อแสดงรายการแบบอักษรที่เก็บไว้ในงานนำเสนอ หากต้องการลบให้ส่งแบบอักษรจากรายการนั้นไปยัง [remove_embedded_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/remove_embedded_font/), แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้แสดงรายการแบบอักษรที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากพบ:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

การลบแบบอักษรที่ฝังไว้จะลบข้อมูลแบบอักษรที่เก็บไว้; มันไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับข้อความ หากแบบอักษรติดตั้งอยู่บนระบบเป้าหมาย ข้อความยังคงใช้แบบอักษรนั้นได้ หากไม่ได้ติดตั้ง การเรนเดอร์อาจต้องอาศัย [font substitution](/slides/th/python-net/font-substitution/) ซึ่งอาจส่งผลต่อการจัดวาง

## **ตรวจสอบข้อมูลแบบอักษรและสิทธิ์การฝัง**

ใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/) เพื่อตรวจสอบแบบอักษรก่อนทำการฝัง เรียก [get_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อดึงแบบอักษรที่ใช้ในงานนำเสนอ สำหรับแต่ละแบบอักษร ส่งอ็อบเจ็กต์ [FontData](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontdata/) และค่าที่ต้องการของ [FontStyleType](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontstyletype/) ไปยัง [get_font_bytes](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_font_bytes/). เมธอดนี้จะคืนค่าข้อมูลไบนารีของสไตล์แบบอักษรนั้น หรือ `None` หากแบบอักษรหรือสไตล์ที่ร้องขอไม่มีอยู่ อย่าส่งผลลัพธ์ `None` ไปยัง [get_font_embedding_level](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_font_embedding_level/) เพราะเมธอดนั้นต้องการอาเรย์บิต

[EmbeddingLevel](https://reference.aspose.com/slides/th/python-net/aspose.slides/embeddinglevel/) เป็นการนับค่าฝากธงที่บ่งบอกข้อจำกัดการฝังที่เก็บอยู่ในแบบอักษร:

- `INSTALLABLE` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่น ตามเงื่อนไขของใบอนุญาตแบบอักษร
- `RESTRICTED` ไม่อนุญาตให้ฝังเว้นแต่จะได้รับอนุญาตจากเจ้าของลิขสิทธิ์แบบอักษรเมื่อเป็นธงการใช้งานเพียงอย่างเดียว
- `PREVIEW_PRINT` อนุญาตให้ใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีแบบอักษรต้องเป็นแบบอ่านอย่างเดียว
- `EDITABLE` อนุญาตให้ใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NO_SUBSETTING` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเฉพาะส่วนย่อยของ glyphs ฝังอักขระทั้งหมดเมื่อธงนี้ปรากฏ
- `BITMAP_ONLY` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเพียง strike แบบบิตแมพเท่านั้น ไม่ได้ข้อมูลโครงร่าง หากแบบอักษรไม่มี strike แบบบิตแมพ จะไม่สามารถฝังได้

สี่ค่าแรกบรรยายสิทธิ์การใช้งาน ส่วน `NO_SUBSETTING` และ `BITMAP_ONLY` สามารถรวมกับพวกมันได้ ตรวจสอบตัวแก้ไขด้วยการดำเนินการบิต เนื่องจาก `INSTALLABLE` มีค่าเป็นศูนย์ ให้ทำมาสก์บิตสิทธิ์การใช้งานและเปรียบเทียบผลลัพธ์กับ `INSTALLABLE` แบบอักษรปัจจุบันควรตั้งบิตสิทธิ์การใช้งานได้มากที่สุดหนึ่งบิต เพื่อความเข้ากันได้กับแบบอักษรเก่าที่ตั้งมากกว่าหนึ่งบิต ตัวช่วยด้านล่างเลือกสิทธิ์ที่ผ่อนคลายที่สุด: `EDITABLE`, จากนั้น `PREVIEW_PRINT`, แล้ว `RESTRICTED`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบปกติ, หนา, เอน, และหนาเอนที่มีสำหรับทุกแบบอักษรที่ `get_fonts` คืนค่า มันข้ามสไตล์ที่ไม่มี, แบบอักษรที่จำกัด, แบบอักษร bitmap‑only, แบบอักษรที่จำกัดเฉพาะ preview และ print เพราะผลลัพธ์ยังคงแก้ไขได้, และแบบอักษรที่ฝังไว้แล้ว หากสไตล์ใดมี `NO_SUBSETTING` มันจะฝังอักขระทั้งหมดสำหรับตระกูลแบบอักษรนั้น

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์แบบอักษร มันไม่ให้ใบอนุญาต ไม่พิสูจน์ว่าคุณได้แบบอักษรมาจากแหล่งที่ถูกต้อง หรือแทนที่การตรวจสอบข้อตกลงใบอนุญาตของแบบอักษรก่อนแจกจ่ายสำเนาที่ฝังไว้

## **เพิ่มแบบอักษรที่ฝังไว้**

ใช้ [add_embedded_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/add_embedded_font/) เพื่อฝังแบบอักษร การโอเวอร์โหลดของเมธอดนี้รับอ็อบเจ็กต์ [FontData](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontdata/) หรืออาเรย์บิตที่มีข้อมูลแบบอักษร ค่าการนับ [EmbedFontCharacters](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/embedfontcharacters/) ควบคุมว่าจะรวมอักขระใดบ้าง:

- [ALL](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/embedfontcharacters/) ฝังอักขระทั้งหมดในแบบอักษร ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและใส่ข้อความใหม่
- [ONLY_USED](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งเน้นการดูเท่านั้น

ตัวอย่างต่อไปนี้ใช้ [get_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อดึงแบบอักษรที่ใช้ใน `Fonts.pptx` และฝังแบบอักษรที่ยังไม่ได้ฝัง แบบอักษรที่เพิ่มต้องมีให้บนเครื่องที่รันโค้ด แบบอักษรที่ฝังไว้เดิมจะคงชุดอักขระปัจจุบันไว้

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **บีบอัดแบบอักษรที่ฝังไว้**

[compress_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) ลดข้อมูลแบบอักษรที่ฝังโดยการลบอักขระที่ไม่ได้ใช้ มันทำงานกับแบบอักษรที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับปริมาณข้อมูลแบบอักษรที่ไม่ได้ใช้ในงานนำเสนอ

ตัวอย่างต่อไปนี้บีบอัดแบบอักษรใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องการเพิ่มข้อความในภายหลัง อักขระที่ลบระหว่างการบีบอัดจะไม่สามารถใช้ได้จากแบบอักษรที่ฝังไว้ แม้ว่าคุณจะฝังอักขระทั้งหมดตั้งแต่แรกก็ตาม

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรที่ฝังไว้ยังจะถูกแทนที่ระหว่างการเรนเดอร์หรือไม่?**

เรียก [get_substitutions](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_substitutions/) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูว่า Aspose.Slides จะเปลี่ยนแบบอักษรใดบ้าง นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/python-net/font-substitution/) และกฎ [font fallback](/slides/th/python-net/fallback-font/) ด้วย Fallback จะจัดการอักขระที่ขาดหาย ดังนั้นการฝังแบบอักษรไม่สามารถแก้ไขอักขระที่แบบอักษรเองไม่มีได้

**ควรฝังแบบอักษรทั่วไปเช่น Arial และ Calibri หรือไม่?**

ให้พิจารณาตามสภาพแวดล้อมเป้าหมาย หากแบบอักษรที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีแบบอักษรเหล่านั้น การฝังสามารถช่วยรักษาการแสดงผลตามที่ตั้งใจไว้ได้ โดยต้องตรวจสอบว่าใบอนุญาตของแบบอักษรอนุญาตให้ฝังหรือไม่