---
title: ฝังแบบอักษรในงานนำเสนอด้วย Python ผ่าน Java
linktitle: แบบอักษรที่ฝังไว้
type: docs
weight: 40
url: /th/python-java/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- ดึงแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการแบบอักษรที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. เพิ่ม, ดึง, ลบ, และบีบอัดแบบอักษรเพื่อรักษาลักษณะข้อความและลดขนาดไฟล์."
---
## **บทนำ**

การฝังแบบอักษรจะเก็บข้อมูลแบบอักษรไว้ภายในงานนำเสนอ PowerPoint เมื่อผู้ชมรองรับแบบอักษรที่ฝังไว้ มันสามารถแสดงข้อความโดยใช้แบบอักษรเหล่านั้นได้แม้ว่าแบบอักษรจะไม่ได้ติดตั้งบนระบบเป้าหมาย สิ่งนี้ช่วยรักษาการขึ้นบรรทัด, ระยะห่างของข้อความ, และการจัดวางสไลด์

Aspose.Slides for Python via Java ให้คุณดึงข้อมูล, เพิ่ม, และลบแบบอักษรที่ฝังไว้ผ่านคลาส [FontsManager] ที่ส่งกลับโดย [Presentation.getFontsManager] คุณยังสามารถลดขนาดข้อมูลแบบอักษรที่ฝังไว้โดยการลบอักษรที่งานนำเสนอไม่ได้ใช้

ตัวอย่างด้านล่างทำงานกับไฟล์ PPTX ก่อนที่จะฝังแบบอักษร ให้แน่ใจว่าข้อมูลแบบอักษรของแบบอักษรนั้นพร้อมใช้งานกับ Aspose.Slides และใบอนุญาตของมันอนุญาตให้ฝังได้

## **รับและลบแบบอักษรที่ฝังไว้**

ใช้ [getEmbeddedFonts] เพื่อแสดงรายการแบบอักษรที่เก็บไว้ในงานนำเสนอ เพื่อที่จะลบแบบอักษรหนึ่ง ให้ส่งแบบอักษรจากรายการนั้นไปยัง [removeEmbeddedFont] แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้แสดงรายการแบบอักษรที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากมีอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

การลบแบบอักษรที่ฝังไว้จะลบข้อมูลแบบอักษรที่เก็บไว้; มันไม่เปลี่ยนแบบอักษรที่กำหนดให้กับข้อความ หากแบบอักษรถูกติดตั้งบนระบบเป้าหมาย ข้อความยังคงสามารถใช้ได้ มิฉะนั้น การเรนเดอร์อาจต้องใช้การแทนที่แบบอักษร ซึ่งอาจส่งผลต่อการจัดวาง

## **ตรวจสอบข้อมูลแบบอักษรและสิทธิ์การฝัง**

ใช้คลาส [FontsManager] เพื่อตรวจสอบแบบอักษรก่อนที่จะฝังมัน เรียก [FontsManager.getFonts] เพื่อดึงแบบอักษรที่ใช้ในงานนำเสนอ สำหรับแต่ละแบบอักษร ให้ส่งอ็อบเจกต์ [FontData] และค่าที่ต้องการของ [FontStyleType] ไปยัง [FontsManager.getFontBytes] วิธีนี้จะคืนค่าข้อมูลไบนารีสำหรับสไตล์แบบอักษรนั้น หรือ `None` เมื่อแบบอักษรหรือสไตล์ที่ร้องขอไม่มีอยู่ อย่าส่งผลลัพธ์ `None` ไปยัง [FontsManager.getFontEmbeddingLevel] เนื่องจากเมธอดนั้นต้องการอาเรย์ของไบต์

[EmbeddingLevel] คือการนับค่าแบบแฟล็กที่รายงานข้อจำกัดการฝังที่เก็บไว้ในแบบอักษร:

- `Installable` อนุญาตการฝังและการติดตั้งถาวรบนระบบอื่น ตามใบอนุญาตของแบบอักษร
- `Restricted` ห้ามการฝัง เว้นแต่จะได้รับอนุญาตจากเจ้าของสิทธิ์ของแบบอักษรเมื่อเป็นแฟล็กการใช้งานเดียวที่อนุญาต
- `PreviewPrint` อนุญาตการใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีแบบอักษรต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตการใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามการฝังเฉพาะบางส่วนของ glyphs; หากมีแฟล็กนี้ต้องฝังอักขระทั้งหมด
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะ bitmap strikes เท่านั้น ไม่ใช่ข้อมูล outlines; หากแบบอักษรไม่มี bitmap strikes จะไม่สามารถฝังได้

ค่าแรกสี่ค่าอธิบายสิทธิ์การใช้งาน ส่วน `NoSubsetting` และ `BitmapOnly` สามารถรวมกับค่าพวกนั้นได้ ตรวจสอบตัวปรับโดยใช้การดำเนินการบิตเวิร์ด เนื่องจาก `Installable` มีค่าเป็นศูนย์ ให้ทำการมาส์กบิตสิทธิ์การใช้งานและเปรียบเทียบผลกับ `Installable` แทนการตรวจสอบเป็นแฟล็ก แบบอักษรปัจจุบันควรกำหนดบิตสิทธิ์การใช้งานได้มากที่สุดหนึ่งบิต เพื่อความเข้ากันได้กับแบบอักษรเก่าที่กำหนดหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนคลายที่สุด: `Editable` แล้วตามด้วย `PreviewPrint` แล้ว `Restricted`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบอักษรปกติ, ตัวหนา, ตัวเอียง, และตัวหนาเอียง ที่มีอยู่สำหรับทุกแบบอักษรที่ `getFonts` คืนค่า มันจะข้ามสไตล์ที่ไม่มี, แบบอักษรที่ถูกจำกัด, แบบอักษร bitmap‑only, แบบอักษรที่จำกัดเฉพาะการแสดงผลและการพิมพ์เนื่องจากผลลัพธ์ยังคงแก้ไขได้, และแบบอักษรที่ฝังไว้แล้ว หากสไตล์ใดที่มี `NoSubsetting` จะฝังอักขระทั้งหมดสำหรับตระกูลแบบอักษรนั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์แบบอักษร มันไม่ได้ให้ใบอนุญาต, พิสูจน์ว่าคุณได้แบบอักษรมาโดยถูกต้องตามกฎหมาย, หรือแทนที่การตรวจสอบข้อตกลงใบอนุญาตของแบบอักษรก่อนที่จะกระจายสำเนาที่ฝังไว้

## **เพิ่มแบบอักษรที่ฝังไว้**

ใช้ [addEmbeddedFont] เพื่อฝังแบบอักษร. การ overload ของมันรับอ็อบเจกต์ [FontData] หรืออาเรย์ของไบต์ที่มีข้อมูลแบบอักษร [EmbedFontCharacters] คือการนับค่าแบบ enum ที่ควบคุมว่าตัวอักษรใดจะถูกรวม:

- [All] ฝังอักขระทั้งหมดในแบบอักษร ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและพิมพ์ข้อความใหม่
- [OnlyUsed] ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งหมายเพื่อการดูเท่านั้น

ตัวอย่างต่อไปนี้ใช้ [getFonts] เพื่อดึงแบบอักษรที่ใช้ใน `Fonts.pptx` และฝังแบบอักษรที่ยังไม่ถูกฝังไว้ แบบอักษรที่ต้องเพิ่มต้องมีอยู่บนเครื่องที่รันโค้ด แบบอักษรที่ฝังอยู่แล้วจะคงชุดอักขระปัจจุบัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **บีบอัดแบบอักษรที่ฝังไว้**

[Compress.compressEmbeddedFonts] ลดข้อมูลแบบอักษรที่ฝังไว้โดยการลบอักขระที่ไม่ได้ใช้ มันทำงานกับแบบอักษรที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นกับจำนวนข้อมูลแบบอักษรที่ไม่ได้ใช้ในงานนำเสนอ

ตัวอย่างต่อไปนี้บีบอัดแบบอักษรใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ถูกลบระหว่างการบีบอัดจะไม่สามารถใช้ได้จากแบบอักษรที่ฝังไว้ แม้ว่าคุณจะฝังอักขระทั้งหมดตั้งแต่แรก

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่ามีการแทนที่แบบอักษรที่ฝังไว้ระหว่างการแสดงผลหรือไม่?**

เรียก [getSubstitutions] ในสภาพแวดล้อมที่คุณแสดงผลงานนำเสนอเพื่อดูว่า Aspose.Slides จะเปลี่ยนแบบอักษรใดบ้าง นอกจากนี้ให้ตรวจสอบการตั้งค่าการแทนที่แบบอักษรและกฎการ fallback ของแบบอักษร การ fallback จัดการกับอักขระที่ขาดหาย ดังนั้นการฝังแบบอักษรไม่สามารถแก้ไขอักขระที่แบบอักษรนั้นไม่มีได้

**ควรฝังแบบอักษรทั่วไปเช่น Arial และ Calibri หรือไม่?**

ให้พิจารณาตัดสินใจตามสภาพแวดล้อมเป้าหมาย หากแบบอักษรที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือแสดงผลงานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีแบบอักษรเหล่านั้น การฝังอาจช่วยรักษาลักษณะตามที่ตั้งใจไว้ ตราบใดที่ใบอนุญาตของแบบอักษรอนุญาตให้ทำเช่นนั้น