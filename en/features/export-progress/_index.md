---
title: Track export progress
description: Receive progress updates during PDF and GIF export.
type: docs
url: /features/export-progress/
weight: 300
feature_id: export-progress
feature_group: operations
translationKey: slides-feature-export-progress
feature_catalogue_version: 2
feature_guides:
- /slides/net/convert-powerpoint-to-pdf/
---

## **Overview**

Attach a progress callback when exporting a presentation so your application can report activity to the user. PDF and GIF export provide progress updates through the save options. Use the output format's progress scale when displaying a percentage or progress bar.

## **FAQ**

**Is the progress scale identical for PDF and GIF?**

No. PDF reports on a 0–100 scale, while GIF uses a fractional scale. Do not assume every save format invokes the callback.

## **Guides**

- [Convert PPT and PPTX to PDF in .NET [Advanced Features Included]](/slides/net/convert-powerpoint-to-pdf/)

Related feature: [Interrupt presentation processing](/slides/features/cancel-processing/).
