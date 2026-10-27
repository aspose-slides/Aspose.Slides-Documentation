---
title: Control memory used by embedded media
description: Set memory thresholds and temporary storage for embedded media.
type: docs
url: /features/memory-management/
weight: 1580
feature_id: memory-management
feature_group: runtime
translationKey: slides-feature-memory-management
feature_catalogue_version: 2
feature_guides:
- /slides/net/manage-blob/
---

## **Overview**

Use BLOB-management options to limit how much embedded media is held in memory and allow larger media to use temporary storage. Choose a temporary directory suitable for the application's workload. These controls are useful for decks with large audio or video content.

## **FAQ**

**Is the media threshold a cap on all memory used by the library?**

No. It applies to embedded binary data. The presentation's slide and shape model still needs memory of its own.

## **Guides**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)

Related feature: [Stream large media while processing presentations](/slides/features/stream-media/).
